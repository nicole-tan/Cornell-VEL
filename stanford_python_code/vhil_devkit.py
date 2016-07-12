# VHIL devkit
# Utilities, shortcuts, and commonly used functionality
# for VHIL development
# 
# By Lucas Sanchez, Summer 2015
# 
# Usage:
# from vhil_devkit import *
# ^This line of code enables you to use 
# any variables/functions defined in
# this file as if you had defined them
# in your own file.
#
# Current features:
# reset()
# keyboardControl(node)
# vhilGo()
# Data collection
# 
# Keypresses used:
# r - reset position and orientation
# # keyboard controls:
# w - forward
# s - backward
# a - pan left
# d - pan right
# q - pan down
# e - pan up
# [arrowkey_up] - tilt up
# [arrowkey_down] - tilt down
# [arrowkey_left] - turn left
# [arrowkey_right] - turn right
# t - reset tilt (pitch)
# y - decrease sensitivity
# u - increase sensitivity
# o - print orientation (euler)
# p - print position

import viz
import vizinput
import vizact
import datetime
from collections import OrderedDict


## Constants ################################################
PPT_ADDRESS = 'PPT0@171.64.33.43'
OCULUSVIEWLINK_PRETRANS = [0.195/2, -0.08, -0.07]

hmd = None

# First used in either _setupHeadTrackers or _setupOtherTrackers
vrpn = None


## viz.MainView aliases ##
MainView = viz.MainView
mainview = MainView


## Reset MainView ############################################
# intended for use with a keypress
# Example: vizact.onkeydown('r', resetPos)

# reset position #
def resetPos(pos=None):
	if pos is None: pos = HOME_POS
	mainview.setPosition(pos)

# reset orientation #
def resetOri(ori=None, hmd=None):
	if ori is None: ori = HOME_ORI
	
#	if RIFT:
	if hmd:
		hmd.getSensor().reset()
	else:
		mainview.setEuler(ori)

# reset both #
# If using a Rift, pass in the hmd handle.
def reset(pos=None, ori=None, rift=None):
	if pos is None: pos = HOME_POS
	if ori is None: ori = HOME_ORI
	
	resetPos(pos)
	if rift: resetOri(ori, rift)
	else: resetOri(ori, hmd)
vizact.onkeydown('r', reset)


## Set up devices #############################################


# Convention: The head position tracker should have virtual ID of 0.
#def setupHeadTrackers(hmd, OH=False):
def _setupHeadTrackers(hmd, OH):
	global vrpn
	if vrpn is None: vrpn = viz.add('vrpn7.dle')

	POS_TRACKER = vrpn.addTracker(PPT_ADDRESS, 0)
	ORI_TRACKER = hmd.getSensor()

	if OH:
		print 'vhil_devkit: Optical heading setup not yet implemented - set OH to False.'
	else:
		tracker = viz.mergeLinkable(POS_TRACKER, ORI_TRACKER)
		oculusViewLink = viz.link(tracker, MainView)
		oculusViewLink.preTrans(OCULUSVIEWLINK_PRETRANS)
	return oculusViewLink

# Given the virtual IDs of the other trackers
# Adds the trackers to the simulation
# Returns their node3ds in an array
def _setupOtherTrackers(otherTrackerVIDs):
	global vrpn
	if vrpn is None: vrpn = viz.add('vrpn7.dle')

	trackers = []
	for id in otherTrackerVIDs:
		trackers.append(vrpn.addTracker(PPT_ADDRESS, id-1))

	return trackers

# Sets up the Rift as the head tracker
# linked to MainView.
def _setupRift(PPT1, OH, **kwargs):
	import oculus
	global hmd
	hmd = oculus.Rift(**kwargs)
	if PPT1:
		oculusViewLink = _setupHeadTrackers(hmd, OH)
	else:
		oculusViewLink = viz.link(hmd.getSensor(), MainView, mask=viz.LINK_ORI)
	
	oculusViewLink.postEuler(HOME_ORI)

# Call this after viz.go().
# Currently can only perform
# a non-OH setup for head tracking.
# Returns a handle to the hmd, 
# as well as an array of all non-head trackers, to be
# used for getting position and euler.
# To get pos and euler of head tracker,
# use MainView.
# otherTrackerVirtualIDs is an array of
# virtual ids of the other trackers being
# used. The virtual ids are the ones
# chosen on the right side of the 'Marker ID'
# dialog box on the PPT computer.
# If PPT1 is False, otherTrackerVirtualIDs is ignored.
def setupHardware(OH=False, otherTrackerVirtualIDs=[], **kwargs):
	otherTrackers = []
	
	if RIFT:
		_setupRift(PPT1, OH, **kwargs)
	if PPT1:
		otherTrackers = _setupOtherTrackers(otherTrackerVirtualIDs)

	reset()
	return hmd, otherTrackers


## VHIL Go ###########################################

# Use instead of viz.go(). Incorporates
# all hardware setup and configuration
# into this one function call.
# Returns whatever was returned by
# setupHardware.
def vhilGo(rift=False, ppt1=False, OH=False, otherTrackerVirtualIDs=[], debug=False, homePos=[0,1.82,0], homeOri=[0,0,0], keyboardcontrol=True, mode=0, **kwargs):
	global RIFT
	global PPT1
	global DEBUG
	global HOME_POS
	global HOME_ORI
	
	# Run-context constants #
	RIFT = rift # Indicates whether we are going to run the simulation on an Oculus Rift.
	PPT1 = ppt1 # Indicates whether we are going to run the simulation in PPT1.
	DEBUG = debug # Indicates whether we are going to run the simulation in debug mode, enabling extra controls and features
	
	# HOME_POS, HOME_ORI: Starting position and orientation of viz.MainView.
	# reset() resets to the home position and home orientation by default.
	HOME_POS = homePos
	HOME_ORI = homeOri
	
	viz.go(mode)
	
	if keyboardcontrol: keyboardControl(viz.MainView)
	
	return setupHardware(OH, otherTrackerVirtualIDs, **kwargs)


## keyboard control ###########################################
	
_KEYS = { 'forward'	: viz.KEY_UP
		,'back' 	: viz.KEY_DOWN
		,'left' 	: viz.KEY_LEFT
		,'right'	: viz.KEY_RIGHT
}

_KC_MOVE_SPEED = 1
_KC_ROTATE_SPEED = 50.0

# Use the keyboard to control the position and euler of any node.
# WASD: x and z
# e: +y
# q: -y
# Arrow keys: yaw and pitch
class _KeyboardControl:
  def __init__(self, targetNode):
    self.control(targetNode)
    vizact.ontimer(0,self.UpdateView)
    vizact.onkeydown('t', self.resetPitch)
    vizact.onkeydown('y', self.slower)
    vizact.onkeydown('u', self.faster)
    vizact.onkeydown('o', self.printEuler)
    vizact.onkeydown('p', self.printPos)
  
  def control(self, node):
    self.target = node
  
  def UpdateView(self):
    yaw,pitch,roll = self.target.getEuler()
    dm = viz.getFrameElapsed() * _KC_MOVE_SPEED
    dr = viz.getFrameElapsed() * _KC_ROTATE_SPEED
    if viz.key.isDown('w'):
      self.target.setPosition([0,0,dm], viz.REL_LOCAL)
    if viz.key.isDown('s'):
      self.target.setPosition([0,0,-dm], viz.REL_LOCAL)
    if viz.key.isDown('a'):
      self.target.setPosition([-dm,0,0], viz.REL_LOCAL)
    if viz.key.isDown('d'):
      self.target.setPosition([dm,0,0], viz.REL_LOCAL)
    if viz.key.isDown(_KEYS['forward']):
      pitch-=dr
    if viz.key.isDown(_KEYS['back']):
      pitch+=dr
    if viz.key.isDown(_KEYS['left']):
      yaw-=dr
    if viz.key.isDown(_KEYS['right']):
      yaw+=dr
    if viz.key.isDown('e'):
      self.target.setPosition([0,dm,0], viz.REL_LOCAL)
    if viz.key.isDown('q'):
      self.target.setPosition([0,-dm,0], viz.REL_LOCAL)
    
    self.target.setEuler([yaw,pitch,roll], mode=viz.ABS_PARENT)
  
  def faster(self):
    print 'increasing sensitivity'
    global _KC_MOVE_SPEED
    global _KC_ROTATE_SPEED
    _KC_MOVE_SPEED += .25
    _KC_ROTATE_SPEED += 10
  def slower(self):
    print 'decreasing sensitivity'
    global _KC_MOVE_SPEED
    global _KC_ROTATE_SPEED
    _KC_MOVE_SPEED -= .25
    _KC_ROTATE_SPEED -= 10

  def resetPitch(self):
    e = self.target.getEuler()
    self.target.setEuler(e[0],0,e[2])
  def printPos(self):
    print str(self.target.getPosition())
  def printEuler(self):
    print str(self.target.getEuler())

kcObj = None
# Allows you to use the keyboard to control the position and
# euler of any node.
def keyboardControl(node):
  global kcObj
  if kcObj is None:
    kcObj = _KeyboardControl(node)
  else:
    kcObj.control(node)


## Collect data ###############################################

DATA_ORI = 1
DATA_POS = 1 << 1

# class DataCollector
# 
# Generalized data collection class for Vizard. Can collect tracking data
# from viz.MainView or any other tracker node. Can also collect information from
# custom data events such as when the user presses a button, etc.
# A script can use multiple DataCollectors - one per data file - for a simulation
# maintaining multiple data files per participant.
#
# Data output file format can be specified by the user in the constructor.
# The default and intended format is csv file, but also works as a txt file.
# 
# A fileheader is always included.
# By default the fileheader prints the following to the data file:
# "participant id,{pid}\ncollected,{timestamp}\n".
# However, the user can specify additional information to be recorded as
# part of the fileheader. See the addToFileheader() function.
#
# Any additional fileheader information should be added before starting to collect data.
# Any trackers should be added before starting to collect data.
#
# Every single entry in the data file includes a timestamp at the beginning.
# 
# This DataCollector class is meant to be powerful and flexible while still maintaining a quick and simple
# interface for basic use cases. Do not be fooled by the following simple examples: if you need them,
# there are many additional options and features so that using this class
# allows almost as much freedom as writing your own data collection code.
# 
# Basic usage examples:
# 
# # Example collecting tracking (position and euler) data
	# dc = DataCollector()
	# dc.addMainviewTracker()
	# dc.startCollecting()
# 
# # Example collecting event data
	# ec = DataCollector(fileSuffix='_eventdata.csv')
	# vizact.onmousedown(viz.MOUSEBUTTON_LEFT, ec.collect, 'left')
	# vizact.onmousedown(viz.MOUSEBUTTON_RIGHT, ec.collect, 'right')
	# vizact.onkeydown('j', ec.collect, 'j key was pressed')
#
# All other features and functionality:
#	-Custom data file names:
#	 The file that will be created for a participant with a given pid
#	 will be opened as the string filePrefix+pid+fileSuffix, where each of those strings
#	 is an optional parameter passed to the __init__() function. If not specified,
#	 filePrefix will be "Data/participant" and fileSuffix will be "_data.csv". Therefore,
#	 if the pid is 1, the data file will be located in the Data/ subdirectory of the
#	 current directory, and will have the filename "participant1_data.csv".
#
#	-Collect tracking data from additional trackers:
#	 See the addTracker() function.
#
#	-Shortcut to disable/enable data collection:
#	 The collectData parameter in the __init__() function is intended to be used with a global
#	 boolean specifying whether the script user/programmer wants to collect data the next time
#	 the script is run. By default, collectData is True. If collectData is False, it effectively
#	 disables the DataCollector being initialized. Every call to
#	 any function in that instance of the DataCollector class will return immediately without
#	 doing anything else. The idea is that the programmer can completely disable and re-enable
#	 data collection simply by changing collectData to False or True, instead of 
#	 commenting/uncommenting any other data collection code.
#	 The data parameter in the vhilGo() function acts the same exact way as the collectData
#
#	-Add information to the fileheader:
#	 See the addToFileheader() function.
#
#	-Specify data collection rate:
#	 See the startCollecting() function.
#
#	-Use multiple data collectors:
#	 As mentioned previously, you can use multiple data collectors in one script.
#	 Just make sure they have different filenames, which means you will have to manually
#	 specify the filename when calling the constructor of at least one of the data collectors.
#	 Example:
#	 dc = DataCollector(filePrefix='Data/trackingdata', fileSuffix='.csv')
#	 ec = DataCollector(filePrefix='Data/eventdata', fileSuffix='.csv')
#
#	-Record switch to next phase of the study:
#	 Use the addLineToData() method to immediately append any string to the datafile. Example:
#	 dataCollector.addLineToData('Starting next phase...')
#
#	-Collect custom (non-tracking) data:
#	 Instead of calling the startCollecting() function, whenever something happens that you want to
#	 collect data about, call the collect() method, passing in any values associated with the event
#	 that you want recorded in the file. A timestamp is automatically included. Example:
#	 if side == 0: dataCollector.collect('left')
#	 elif side == 1: dataCollector.collect('right')
# 
class DataCollector:
	pid = None
	
	# Constructs the DataCollector. If no pid is given, the function will open a vizinput dialog
	# asking the user to specify one. The first three parameters specify the name of the data file
	# that will be created by calling the open() system call. By default, if the pid is 1, the call
	# to open will be: open("Data/participant1_data.csv")
	# The Data folder must be already created before the script is run to avoid errors.
	# If you change filePrefix, remember to include any directories in the path.
	# If you change fileSuffix, remember to include the file extension.
	def __init__(self,
		filePrefix="Data/participant", # Include any directories in the path. Make sure to create the directories first.
		pid=None, # Participant number/id (can be number or string)
		fileSuffix="_data.csv", # Include file extension
		collectData=True, # Set this to False to make every method call to this object do nothing and return immediately
		):
		
		self.locked = not collectData
		if self.locked:
			print 'Data will not be collected because collectData is set to False.'
			return
		
		self.trackers = []
		
		if pid == None:
			if DataCollector.pid == None:
				DataCollector.pid = vizinput.input('Please enter the participant number.')
		else:
			DataCollector.pid = pid

		filepath = '{0}{1}{2}'.format(filePrefix, DataCollector.pid, fileSuffix)
		self.datafile = open(filepath, 'a')
		
		self._fileheader()
	
	# Adds a file header with two fields: Participant ID and
	# Time Collected.
	def _fileheader(self):
		if self.locked: return
		
		timestamp = datetime.datetime.now()
#		header = "participant id,{0}\ncollected,{1}\n".format(DataCollector.pid, timestamp)
		header = "participant id,{0}\ntimestamp,{1}\nWorldName,{1}\n".format(DataCollector.pid, timestamp)
		
		self.datafile.write(header)
	
	# Use this method to add more information to the file header.
	# This method should be
	# called after the constructor but before any data is collected.
	# This method takes additional information in the form of key-value
	# pairs as arguments to this method. For example, let us imagine that
	# you want to note in the file header that the participant's age is 21 and the condition
	# that s/he is running the study in is condition 3. Then, we would have
	# two key-value pairs: one with a key of 'condition' and a value of 3,
	# and another with a key of 'participant age' and a value of 21. There
	# are two different approaches we can use to add these key-value pairs
	# to the header using this method. Both of these approaches add the
	# key-value pairs alphabetically by key, even if they weren't given
	# alphabetically.
	#
	# Approach 1: Use keyword arguments
	#	dataCollector.addToFileheader(condition=3, participantAge=21)
	#	Result in file:
	#	"condition,3\nparticipantAge,21\n"
	#
	# Approach 1 is cleaner, but use Approach 2 if you want the keys to be
	# able to have spaces, hyphens, etc.
	# 
	# Approach 2: Use a dictionary object (note the curly braces)
	#	dataCollector.addToFileheader( {'condition': 3, 'participant age': 21} )
	#	Result in file:
	#	"condition,3\nparticipant age,21\n"
	#
	def addToFileheader(self, keyvals={}, **kwargs):
		if self.locked: return
		
		moreHeader = ""
		# Append key-value pairs alphabetically to the file
		orderedKeyvals = OrderedDict(sorted(keyvals.items()))
		for key, val in orderedKeyvals.iteritems():
			moreHeader += "{0},{1}\n".format(key, val)
		
		# Append keyword arguments alphabetically to the file
		orderedKwargs = OrderedDict(sorted(kwargs.items()))
		for key, val in orderedKwargs.iteritems():
			moreHeader += "{0},{1}\n".format(key, val)
		
		self.datafile.write(moreHeader)

	# Struct to organize the information needed to
	# collect data for one tracker.
	class TrackerInfo:
		def __init__(self, node, dataType, name):
			self.node = node
			self.dataType = dataType
			self.name = name

	# Specify a new tracking node to record tracking
	# data from.
	# Given the node, the type(s) of data
	# to collect, and the name to use
	# to refer to the given node within the output file.
	# The node must be an object you can call getPosition()
	# and/or getEuler() on.
	# The types of data are specified by two constants:
	# DATA_POS and DATA_ORI. DATA_POS indicates position
	# data and DATA_ORI indicates orientation/euler data.
	# To collect both position and orientation data on
	# the given node, use DATA_POS | DATA_ORI.
	# Example:
	# leftHand = vrpn.addTracker(PPT_ADDRESS, 2)
	# addTracker(leftHand, DATA_POS | DATA_ORI, 'left hand')
	def addTracker(self, node, dataType, name):
		if self.locked: return
		tracker = self.TrackerInfo(node, dataType, name)
		self.trackers.append(tracker)
	
	# Shortcut method equivalent to:
	# dataCollector.addTracker(MainView, DATA_POS | DATA_ORI, 'head')
	def addMainviewTracker(self):
		if self.locked: return
		self.addTracker(MainView, DATA_POS | DATA_ORI, 'head')

	# Use this to manually append lines of data to the
	# output file. This method adds a newline character 
	# to the given string and adds the resulting line
	# to the output file.
	def addLineToData(self, line):
		if self.locked: return
		self.datafile.write('\n'+line)
		self.datafile.flush()

	# Call this method to print the given arguments to a
	# line in the file. The collect method is a wrapper for
	# this function if any arguments are passed to collect.
	def _collectCustom(self, *args):
		if self.locked: return

		result = 'Time,' + str(datetime.datetime.now()) + '\n'
		for a in args:
			result += ',' + str(a)

		result += '\n'
		self.addLineToData(result)

	def collect(self, *args):
		if self.locked: return
		
		if len(args):
			self._collectCustom(*args)
			return

		result = 'Time,' + str(datetime.datetime.now()) + '\n'

		for tracker in self.trackers:

			if tracker.dataType & DATA_POS:
				result += ","
				result += tracker.name + ",pos,"
				pos = tracker.node.getPosition()
				result += str(pos[0]) + ","
				result += str(pos[1]) + ","
				result += str(pos[2]) + "\n"
			
			if tracker.dataType & DATA_ORI:
				result += ","
				result += tracker.name + ",ori,"
				eu = tracker.node.getEuler()
				result += str(eu[0]) + ","
				result += str(eu[1]) + ","
				result += str(eu[2]) + "\n"

		self.addLineToData(result)

	# Private method, call startCollecting instead
	def _collectPeriodically(self):
		if self.locked: return
		self.timer = vizact.ontimer(self.collectRate, self.collect)

	# Collects data at the given rate (in seconds between each collection)
	# Set collectRate to 0 to collect as often as possible.
	def startCollecting(self, collectRate=.1):
		if self.locked: return
		self.collectRate = collectRate
		viz.director(self._collectPeriodically)

	def stopCollecting(self):
		if self.locked: return
		self.timer.remove()


#if __name__ == '__main__':
#	viz.go()