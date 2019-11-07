pragma solidity ^0.5.0;

//pragma experimental ABIEncoderV2;

import "browser/BokkyPooBahsDateTimeLibrary.sol";

contract Counter15  {
    
    struct TariffZone{
        uint8 zone_id;
        uint32 rate_per_1000;
        bool exists;
    }
    mapping(uint8=>TariffZone) private tariff_zone;
    
    uint8[] private tariff_zones_keys;
    
    struct BankAccount{
        uint32 user_account_id;
        bytes16 autopay_sensor_id;
        bool exists;
    }
    mapping(uint32=>BankAccount) private bank_accounts;
    uint32[] private bank_account_keys;
    
    struct SensorData{
        uint256 index; 
        bytes16 sensor_id;
        uint64 counter;
        uint256 created;
        uint8 month;
        uint16 year;
    }
    struct MSensorData{
        uint256 index; 
        bytes16 sensor_id;
        uint64 counter;
        uint256 created;
        uint8 month;
        uint16 year;
        mapping(uint=>SensorData[]) mdata;
        mapping(uint=>SensorData) last_data;
        mapping(uint=>uint) offset;
        mapping(uint=>uint) amount;
    }    
    struct BillingData{
        bytes16 sensor_id;
        bool exists;
        bool is_pre_invoice_needed;
        bool is_final_invoice_needed;
        bool is_pre_invoice_ready;
        bool is_final_invoice_ready;
        bool is_invoice_payed;
        
        uint8 month;
        uint16 year;
        uint64 final_invoice_counters;
        uint64 pre_invoice_estimated_costs;
        uint64 final_invoice_costs;
        uint256 final_invoice_payed_on;
    }
    //sensor monthly data
    mapping(bytes16=>SensorData[]) private data;
    
    mapping(bytes16=>MSensorData) private datas;
    

    
    //absolute sensor counter value
    mapping(bytes16=>mapping(uint32=>uint64)) private cnt_data;
    //sensor monthly counters amount
    mapping(bytes16=>mapping(uint32=>uint64)) private amount_data;
    //last sensor data
    mapping(bytes16=>SensorData) private last_data;
    
    //reserved
    mapping(bytes16=>mapping(uint32=>uint64)) private last_costs;
    //last sensor counters value
    mapping(bytes16=>uint64) private last_value;
    //sensor last month last counters value(used to calculate current month amount)
    mapping(bytes16=>uint64) private offset;
    //sensor monthly billing profile
    mapping(bytes16=>mapping(uint32=>BillingData)) private billing;
    //sensor avarage daily consumption in value amount
    
    
    function add_data(bytes16 _sensor_id, uint64 _counter, uint256 _created) public
    {
        SensorData[] memory d=data[_sensor_id];

        uint256 len = d.length;
        
        uint16 _year = 2019;//uint16(BokkyPooBahsDateTimeLibrary.getMonth(_created));
        
        uint8 _month = 11;//uint8(BokkyPooBahsDateTimeLibrary.getYear(_created));
        
        
        SensorData memory  sd=SensorData({index:d.length+1,sensor_id:_sensor_id,counter:_counter, created:_created, month:_month, year:_year });
            
        data[_sensor_id].push(sd);
        
        
        datas[_sensor_id].mdata[2019*11].push(sd);

        datas[_sensor_id].last_data[2019*11] = sd;

        if(datas[_sensor_id].mdata[2019*11].length==0){
            datas[_sensor_id].offset[2019*11] = last_value[_sensor_id];
        }
        datas[_sensor_id].amount[2019*11] = _counter - datas[_sensor_id].offset[2019*11];
        
        last_value[_sensor_id] = _counter;
      /*  
        last_data[_sensor_id] = sd;
        
        //cnt_data[_sensor_id][_year*12+_month] += 1;
        
        if(len==0){
            offset[_sensor_id] = last_value[_sensor_id];
        }
        
        amount_data[_sensor_id][_year*12+_month] = _counter-offset[_sensor_id];
        
        last_value[_sensor_id] = _counter;
    */
    }
    function get_val(bytes16 sensor_id) public view returns (uint counter, uint amount){

        counter=datas[sensor_id].last_data[2019*11].counter;
        amount=datas[sensor_id].amount[2019*11];
    }
    function get_data(bytes16 sensor_id, uint256 index) public view returns (uint value){
        //SensorData[] memory d=data[sensor_id];
        //value = d[index].year;
        
        //MSensorData memory d=;
        value=datas[sensor_id].mdata[2019*11][index].year;
    }
    function get_data_len(bytes16 sensor_id, uint16 year, uint8 month) public view returns (uint256 value){
        //SensorData[] memory d=data[sensor_id];
        //value = d.length;
        value=value=datas[sensor_id].mdata[2019*11].length;
    }
    
    function process_billing(bytes16 sensor_id) public 
    {
        uint256 _now = now;
        
        uint16 _year = uint16(BokkyPooBahsDateTimeLibrary.getMonth(_now));
        
        uint8 _month = uint8(BokkyPooBahsDateTimeLibrary.getYear(_now));
        
        uint8 day = uint8(BokkyPooBahsDateTimeLibrary.getDay(_now));
        
        uint64 month_amount = amount_data[sensor_id][_year*12+_month];
        
        uint64 daily_avg_amount = month_amount/uint8(day);
        
        uint8 days_total=uint8(BokkyPooBahsDateTimeLibrary.getDaysInMonth(_now));
        
        uint8 days_to_end = days_total - day;
        
        uint64 estimated_costs = days_to_end * daily_avg_amount + month_amount;
        
        if(!billing[sensor_id][_year*12+_month].exists)
        {
            billing[sensor_id][_year*12+_month] = 
            BillingData({
                sensor_id:sensor_id,
                exists:true,
                is_pre_invoice_needed:true,
                is_final_invoice_needed:true,
                is_pre_invoice_ready:false,
                is_final_invoice_ready:false,
                is_invoice_payed:false,
                month:_month,
                year:_year,
                final_invoice_counters:month_amount,
                pre_invoice_estimated_costs:estimated_costs,
                final_invoice_costs:0,
                final_invoice_payed_on:0
                });
        }
        else{
            billing[sensor_id][_year*12+_month].final_invoice_counters=month_amount;
            billing[sensor_id][_year*12+_month].pre_invoice_estimated_costs=estimated_costs;

        }
        
        
        
    }
    
    struct Sensor{
        bytes16 sensorId;
        uint8 zone_id;
        bool exists;
        int64 sensor_data_hash;
        //SensorData[] data;
        mapping(bytes16=>SensorData)data;
        bytes16[] sensor_data_keys;
        int64 sensor_hash;
    }
    int64 tariff_zone_chksum;
    
    
    bool tariff_loaded = false;
    
    uint32 private tariff_zones;
    
    mapping(bytes16=>Sensor) private sensors;
    mapping(bytes16=>SensorData) private lastCounters;
    
    bytes16[]sensor_keys;
    
    constructor() public{
        
        tariff_loaded=false;
        
        tariff_zones=0;
        
        tariff_zone_chksum=0;
    }
    
    
   /* 
    function getCurrentInvoice(uint32 _user_account_id) public view returns (uint32 user_account_id, uint64 value){
        
        
        
        if(bank_accounts[_user_account_id].exists){
            bytes16 sensor_id = bank_accounts[_user_account_id].autopay_sensor_id;
            
            if(lastCounters[sensor_id].key!=0){
                
                uint64 counters = lastCounters[sensor_id].counter;
                
                uint8 zone_id = sensors[sensor_id].zone_id;
                
                uint32 rate_per_1000 = tariff_zone[zone_id].rate_per_1000;
                
                user_account_id = _user_account_id;
                
                value = rate_per_1000*counters;
                
                
            }
        }
    }
    
    function insertBankAccount(uint32 _user_account_id, bytes16 _autopay_sensor_id) public{
        // if(!bank_accounts[_user_account_id].exists){
        //     bank_account_keys.push(_user_account_id);
        // }
        bank_accounts[_user_account_id]=BankAccount({user_account_id:_user_account_id,autopay_sensor_id:_autopay_sensor_id,exists:true });

   
    }
    function getBankAccount(uint32 _user_account_id) public view returns(uint32 user_account_id, bytes16 autopay_sensor_id){
        user_account_id=bank_accounts[_user_account_id].user_account_id;
        autopay_sensor_id=bank_accounts[_user_account_id].autopay_sensor_id;    
    }    

    
    function getTariffZones() public view returns (uint32) {
        return tariff_zones;
    }
    
    function loadTariffZone(uint8 _zone_id, uint32 _rate_per_1000) public {

        if(!tariff_zone[_zone_id].exists)
        {
            tariff_zones_keys.push(_zone_id);
            
            tariff_zones+=1;
        
            tariff_loaded=true;
        }
        
        tariff_zone[_zone_id]= TariffZone(_zone_id,  _rate_per_1000, true);
        
    }
    function getTariffZoneByZoneId(uint8 zone_id) public view returns (uint32){
        
        return tariff_zone[zone_id].rate_per_1000;
    }
    
    function getTariffZoneChkSum() public view returns (int64){
        
        return tariff_zone_chksum;
    }
    function setTariffZoneChkSum(int64 chksum) public{
        
        tariff_zone_chksum=chksum;
    }    
    function emptyTariffZoneChkSum() public{
        
        tariff_zone_chksum=0;
        
        tariff_zones=0;
        
        delete tariff_zones;
        
        delete tariff_zones_keys;

    }     


    function insertSensor(bytes16 _sensorId) public{
        
        if(!sensors[_sensorId].exists){
                sensor_keys.push(_sensorId);
        }
        
        sensors[_sensorId]=Sensor({sensorId:_sensorId, sensor_data_hash:0, zone_id:1, exists:true,  sensor_data_keys:new bytes16[](0),sensor_hash:0 });
    }
    function getSensor(bytes16 _sensorId) public view returns(bytes16 _sensor_id, uint8 _zone_id, int64 _sensor_data_hash){
        
        if(sensors[_sensorId].exists){
                return (_sensorId, sensors[_sensorId].zone_id, sensors[_sensorId].sensor_data_hash);
        }
    }
    function insertLastSensorCounters(bytes16 _sensorId,bytes16 _sensorDataId, uint64 _lastCountersValue, uint256 _lastCountersDateTime) public{
        //if(sensors[_sensorId].exists)
            lastCounters[_sensorId]=SensorData({key:_sensorDataId, counter:_lastCountersValue, lastCounterSyncDate:_lastCountersDateTime});
    }
    function getLastSensorCounters(bytes16 _sensorId) public view returns (bytes16 _sensorDataId, uint64 _lastCountersValue, uint256 _lastCountersDateTime){
        _sensorDataId=lastCounters[_sensorId].key;
        _lastCountersValue=lastCounters[_sensorId].counter;
        _lastCountersDateTime=lastCounters[_sensorId].lastCounterSyncDate;
        
    }
    
    function getSensorHash(bytes16 _sensorId) public view returns (int64){
        
       // if(sensors[_sensorId].exists)
            return sensors[_sensorId].sensor_hash;
        //else
            //return 0;
    }
    function setSensorHash(bytes16 _sensorId, int64 hash) public{
        
        if(sensors[_sensorId].exists)
            sensors[_sensorId].sensor_hash=hash;
    }    
    function getSensorDataHash(bytes16 _sensorId) public view returns (int64){
        
        if(sensors[_sensorId].exists)
            return sensors[_sensorId].sensor_data_hash;
        else
            return 0;
    }
    function setSensorDataHash(bytes16 _sensorId, int64 hash) public{
        
        if(sensors[_sensorId].exists)
            sensors[_sensorId].sensor_data_hash=hash;
    }

    function insertSensorData(bytes16 _sensorId, bytes16 _sensorDataId, uint64 _counter) public{

        if(sensors[_sensorId].exists){
            sensors[_sensorId].data[_sensorDataId]=SensorData({key:_sensorDataId,counter: _counter,lastCounterSyncDate:now });
        }
    }
    
    function getSensorData(bytes16 _sensorId, bytes16 _sensorDataId) public view returns(bytes16, uint64, uint256 ){
        //if(sensors[_sensorId].exists){
           return (
            sensors[_sensorId].data[_sensorDataId].key,
            sensors[_sensorId].data[_sensorDataId].counter, 
            sensors[_sensorId].data[_sensorDataId].lastCounterSyncDate
            );
       // }
    }
    
    
    struct UserData{
        string email;
        uint age;
        uint index;
    }
    mapping(address => UserData) private userData;
    
    address[] private userIndex;
    
    function bytes32ToString(bytes32 x) public returns (string memory) {
        bytes memory bytesString = new bytes(32);
        uint charCount = 0;
        for (uint j = 0; j < 32; j++) {
            byte char = byte(bytes32(uint(x) * 2 ** (8 * j)));
            if (char != 0) {
                bytesString[charCount] = char;
                charCount++;
            }
        }
        bytes memory bytesStringTrimmed = new bytes(charCount);
        for (uint8 j = 0; j < charCount; j++) {
            bytesStringTrimmed[j] = bytesString[j];
        }
        return string(bytesStringTrimmed);
    }
    
    function insertUser(address userAddress, bytes32 email, uint age) public returns(uint index)
    {
        //if(isUser(userAddress)) throw; 
        
        userData[userAddress].email = bytes32ToString(email);
        userData[userAddress].age   = age;
        userData[userAddress].index = userIndex.push(userAddress)-1;

        return userIndex.length-1;
    }
    function getUser(address userAddress) public view returns(string memory userEmail, uint userAge, uint index)
    {
    //if(!isUser(userAddress)) throw; 
    return(
      userData[userAddress].email, 
      userData[userAddress].age, 
      userData[userAddress].index);
    }
    */
}
    
