pragma solidity ^0.5.12;
contract Counter2 {
    
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