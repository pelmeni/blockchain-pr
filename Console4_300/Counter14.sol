pragma solidity ^0.5.1;

pragma experimental ABIEncoderV2;



contract Counter14  {
    
    
    struct BankAccount{
        uint32 user_account_id;
        bytes16 autopay_sensor_id;
        bool exists;
        // uint64 balance;
        // uint256 balance_last_sync;
        // uint64 chksum;
    }
    
    constructor() public{
        
        tariff_loaded=false;
        
        tariff_zones=0;
        
        tariff_zone_chksum=0;
    }
    
    mapping(uint32=>BankAccount) private bank_accounts;
    uint32[] private bank_account_keys;
    
    
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

    struct TariffZone{
        uint8 zone_id;
        uint32 rate_per_1000;
        bool exists;
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

    int64 tariff_zone_chksum;
    
    mapping(uint8=>TariffZone) private tariff_zone;
    
    uint8[] private tariff_zones_keys;
    
    bool tariff_loaded = false;
    
    uint32 private tariff_zones;
    
    
    
    
    
    struct SensorData{
        bytes16 key;
        uint64 counter;
        uint256 lastCounterSyncDate;
    }
    struct Sensor{
        bytes16 sensorId;
        uint8 zone_id;
        //string sensorText;
        bool exists;
        int64 sensor_data_hash;
        //SensorData[] data;
        mapping(bytes16=>SensorData)data;
        bytes16[] sensor_data_keys;
        int64 sensor_hash;
    }
    mapping(bytes16=>Sensor) private sensors;
    mapping(bytes16=>SensorData) private lastCounters;
    
    bytes16[]sensor_keys;

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
    
    int private count = 0;
    function incrementCounter() public {
        count += 1;
    }
    function decrementCounter() public {
        count -= 1;
    }
    function getCount() public view returns (int) {
        return count;
    }
}