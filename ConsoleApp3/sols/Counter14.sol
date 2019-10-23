pragma solidity ^0.5.1;

pragma experimental ABIEncoderV2;

import "github.com/provable-things/ethereum-api/provableAPI_0.4.25.sol";


contract Counter14  {
    
    constructor() public{
        
        tariff_loaded=false;
        
        tariff_zones=0;
    }
    
    bool tariff_loaded = false;
    uint32 private tariff_zones;
    
    struct TariffZone{
        uint8 zone_id;
        uint32 rate_per_1000;
    }
    function getTariffZones() public view returns (uint32) {
        return tariff_zones;
    }
    
    function loadTariffZone(uint8 zone_id, uint32 rate_per_1000) public {
        tariff_zone[zone_id]=rate_per_1000;
        
        tariff_zones+=1;
        
        tariff_loaded=true;
    }
    function getTariffZoneByZoneId(uint8 zone_id) public view returns (uint32){
        
        return tariff_zone[zone_id];
    }
    function getHello() public returns (string memory){
        return provable_query("URL", "http://localhost:8080/hello");
    }
    
    mapping(uint8=>uint32) private tariff_zone;
    
    struct SensorData{
        address account;
        uint64 counter;
        uint256 lastCounterSyncDate;
    }
    struct Sensor{
        address account;
        uint8 zone_id;
        string title;
        uint64 data_length;
        SensorData[] data;
    }
    
    mapping(address=>Sensor) private sensor;
    
    function insertSensor(address account, uint8 zone_id, string memory title) public{
        sensor[account].account=account;
        sensor[account].zone_id=zone_id;
        sensor[account].title=title;
        sensor[account].data_length=0;
    }
    function getSensor(address account) public view returns (address s_account, uint8 s_zone_id, string memory s_title, uint64 sdata_length){
        return (sensor[account].account,
                sensor[account].zone_id,
                sensor[account].title,
                sensor[account].data_length
        );
    }

    function insertSensorData(address account, uint64 counter) public{
        sensor[account].data.push(SensorData(account, counter,now));
        sensor[account].data_length++;
    }
    
    function getSensorData(address account, uint64 index) public view returns(uint64 , uint256 , uint64 ){

                return (
                    sensor[account].data[index].counter, 
                    sensor[account].data[index].lastCounterSyncDate,
                    index
                    );
        
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