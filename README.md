# Cornell Virtual Engagement Lab

##Tracking
The tracking section uses Unity and C# scripts to create three CSV files that record the date-time stamps [to the millisecond for accuracy], position, and rotation of the HTC Vive headset as well as the left and right controllers. If the time is the same for recorded output, it will be displayed in the CSV file in the order head, left controller, right controller (the body part is also notated at the end of each recorded line).

###General 
The outputted information is determined by an absolute coordinate system, indicated by the ball at the center of the screen. 
The information is recorded immediately when the play button is pressed. <br />
When the space button is pressed, the output stops being recorded to the CSV file. When it is pressed again, recording continues. <br /> 
To delete recorded output, press either the l, h, or r key [left controller, head, right controller respectively]. <br />
Once the application is quit, a series of new lines and a line of asterisk delimeters will be entered to separate run-through data. 

####Left and Right Controllers
If only one controller is being used, the RightController.csv file will contain the tracking information for that moving controller. When both controllers are active, the one that is leftmost in space is recorded as left. 

###Events
Events are recorded by pressing down the 'E' key. This records down the timestamp and event name, as well as the location and rotation for that particular event, making it easy to debug tracking movements. 

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

##Character
The given character [Kyle the Robot] is an imported model from Unity's free assets. The head and bodily motions of the headset and controllers are accurately reflected in the first person movements of Kyle the Robot. A mirror is set up in the scene in order to better debug movements. Though the movements themselves are currently accurate, the resulting movements do not perfectly correspond to the movements of attached joints which is a problem we are currently working on fixing. 

###Character Scripting
The character's movements all correspond to a script, Avatar Movement, that changes the movement of the avatar's body in correspondence with the movements of the head mounting device as well as that of the two controllers. This prevents the separation of body parts that would occur when attaching part of the body to SteamVR's individual camera rigs.

###To Be Implemented
* Recording data in columns
* Kill fixed update --> judder change?
* Preferences screen where you can customize the username [for the file], the event name, saving to an existing file, etc 
* Remove toggling of keypresses for now
* Download test games
* Run in beta?
* Link controllers to stock robot
* Create a dialogue box that allows you to choose the user and will allow you to either create a new file or use an existing one
* Create a new file every single time a button is pressed
* Have a more visual way of viewing the data
* Customizable keypresses 
* Looking into animation tutorials to figure out how to move the skeleton of avatars
* High fiedlity - networked second life VR spinoff



