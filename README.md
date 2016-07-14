# Cornell Virtual Engagement Lab

##Tracking
The tracking section uses Unity and C# scripts to create a single CSV file that records the time and date stamps, position, and rotation of the HTC Vive headset as well as the left and right controllers. If the time is the same for recorded output, it will be displayed in the CSV file in the order head, left controller, right controller (the body part is also notated at the end of each recorded line).

###General 
The outputted information is relative to the starting location [before movement] of the headset and controllers. The information is recorded immediately when the play button is pressed. <br />
When the space button is pressed, the output stops being recorded to the CSV file. When it is pressed again, recording continues. <br /> 
To delete recorded output, press either the l, h, or r key [left controller, head, right controller respectively]. <br />
Once the application is quit, a series of new lines and a line of asterisk delimeters will be entered to separate run-through data. 

####Left and Right Controllers
If only one controller is being used, the RightController.csv file will contain the tracking information for that moving controller. When both controllers are active, the one that is leftmost in space is recorded as left. 

###Testing
1. Left hand: 
           Up and down 5x <br />
           Side to side 5x [right then left] <br />
           Back and forth 5x <br />
           Pitch 5x <br />
           Yaw 5x <br />
           Roll 5x <br />
2. Right hand: 
            Up and down 5x <br />
            Side to side 5x <br />
            Back and forth 5x <br />
            Pitch 5x <br />
            Yaw 5x <br />
            Roll 5x <br />
3. Head: 
      Down and up 5x <br />
      Side to side 5x <br />
      Back up, go forward 5x <br />
      Pitch 5x <br />
      Yaw 5x <br />
      Roll 5x 

###To Be Implemented
* Create a dialogue box that allows you to choose the user and will allow you to either create a new file or use an existing one
* Have an absolute coordinate system [the origin would be indicated by a point in the game area]
* Create a new file every single time a button is pressed
* Have a more visual way of viewing the data
* Include an avatar to make movement seem more natural [Maya]
* Customizable keypresses 



