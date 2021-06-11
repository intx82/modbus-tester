# modbus-tester
Modbus device tester

## Scripts

Script contains instructions that will be transferred into serial port. 
Currently, scripts has only two type of instructions:

* Hex string. Could have different byte separators, like: space, '-', '_' or not have at all. For example:
  - 00010203040506 
  - 0A-04-00-10-00-03
  
To all transmitted data, will calculate modbus CRC and transmitted with provided body. So for provided example below in port will be transmitted: 0A-04-00-10-00-03-B0-B5
 
* Delay command with time in ms as an additional argument. Example:
  - Delay 1000 -> will delay for 1s
  
### Script example

```Script
0A-04-00-10-00-03
delay 10
0A-04-00-30-00-06
```

Script should have *.scr file extension. 

## Logs

As report of running example script on real device, will be created log file. 
Example of 'Log file'

```Log
2021-06-10 15:53:30.8882 INFO Open: D:\wrk\sharp\zerd.modbus\test-dir\04-generator-test.scr. Port: COM9 : 115200
2021-06-10 15:53:30.9677 INFO TX: 0A-04-00-10-00-03-B0-B5
2021-06-10 15:53:40.1890 INFO RX: 0A-04-06-00-00-00-02-00-0C-B2-66
2021-06-10 15:53:40.1890 INFO Delay 10 ms
2021-06-10 15:53:40.2010 INFO TX: 0A-04-00-30-00-06-71-7C
2021-06-10 15:53:45.4277 INFO RX: 0A-04-0C-7F-00-52-00-12-50-4E-33-52-35-34-20-E5-C4
2021-06-10 15:53:45.5451 INFO Close D:\wrk\sharp\zerd.modbus\test-dir\04-generator-test.scr
```
