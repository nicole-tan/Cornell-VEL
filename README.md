# Cornell Virtual Embodiment Lab

##Tracking
The tracking section uses Unity and C# scripts to create three CSV files that record the date-time stamps [to the millisecond for accuracy], position, and rotation of the HTC Vive headset as well as the left and right controllers. If the time is the same for recorded output, it will be displayed in the CSV file in the order head, left controller, right controller (the body part is also notated at the end of each recorded line).

###General 
The outputted information is determined by an absolute coordinate system, with the origin indicated by the ball at the center of the screen. 
The information is recorded immediately when the play button is pressed or when the build is executed. <br />
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
The given character [secretary] is an imported model from Unity's free assets. The head and bodily motions of the headset and controllers are accurately reflected in the first person movements of the character. A mirror is set up in the scene in order to better debug movements. 

###Character Progress
The arms have been separated from the rest of the character mesh. The rigging within each of the arms allow for proper wrist movement. Also added on are controllers that are held within each hand. As of now, all wrist, elbow, and shoulder movement is accurately tracked with the exception of some wrist deformation when twisting the arms along the x-axis. Next to be added are the two feet, which will then be tracked by two more Vive controllers. 

###Character Scripting
The character's head and torso movements all correspond to a script, Avatar Movement, that changes the movement of the avatar's body in correspondence with the movements of the head mounting device. Another script, Hand Movements, corresponds to the left and right controller rotation and position. It allows for wrist turning and twisting as well as elbow and shoulder movements. 

###To Be Implemented
* Recording data in columns
* Kill fixed update --> judder change?
* Preferences screen where you can customize the username [for the file], the event name, saving to an existing file, etc 
* Remove toggling of keypresses for now
* Run in beta?
* Create a dialogue box that allows you to choose the user and will allow you to either create a new file or use an existing one
* Create a new file every single time a button is pressed
* Have a more visual way of viewing the data
* Customizable keypresses 
* High fidelity - networked second life VR spinoff
* Create customizable avatars and characters in VR
* Adding in new room dimensions and look 
* Perfecting the hand movements
* Scaling the human avatar with that shown on the screen --> Script according to the headset distance from floor
* Prevention of unnatural hand movements 
* Fixing of the ugly Unity meshes
* Model the surrounding room 
* Add legs and have them follow the arm movement appropriately 

###Helpful Links
*Rigging a skeleton in Maya: https://www.youtube.com/watch?v=gUPbbhnUXhY
Hope? https://www.youtube.com/watch?v=bls91XlQHSY, https://www.youtube.com/watch?v=KYY7qo0z5h8, https://www.youtube.com/watch?v=A12gtS4oOgo
*Was able to remove the upper arm rotation with the help of this link (http://serrarens.nl/passervr/inverse-kinematics-for-arms-in-unity-freeindie/) 




