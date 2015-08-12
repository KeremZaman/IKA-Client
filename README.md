# IKA-Client
IKA is a project that aims to control an ATV from any computer over Internet connection.
IKA-Client is a client app connected to a Raspberry Pi as a server in the vehicle. It sends commands in JSON format to Raspbberry Pi
and IKA-Server, which is a Python application, processes incoming data and accomplish tasks according to commands.

<b>GENERAL FEATURES:</b>
- 3 headlights and their angel eyes can  be controlled  in 2 mode. First mode is On/Off mode which is switching on and off in classical manner.
Second mode is Blink mode that makes headlights blinking while it's open.

- Direction of the vehicle  be controlled  with A and D keys from keyboard as well as you can see the current direction.

- Acceleration can be set with W and S keys from keyboard. Also, current speed is showed on screen.

- Brakes are controlled with right Shift key. While it is pressed, brakes are applied.

- Horn can be controlled with Space key in the same manner with brakes.

- The view from the camera of vehicle can be viewed simultaneously.

<b>SPEECH RECOGNITION:</b>

Client has a speech recognition feature. You can control vehicle with your voice commands. Note that you can give commands while M key is
pressed only.
<b>1- Headlight Control</b>

Headlight names are "left headlight","right headlight","top headlight","angel eyes".

In the following commands, given headlight will be switched on.

Turn on [<i>headlight_name]</i>

In the following commands, given headlight will be switched off.

Turn off [<i>headlight_name]</i>

In the following commands, blink mode will open for given headlight.

Blink on [<i>headlight_name]</i>

In the following commands, blink mode will close for given headlights.

Blink off [<i>headlight_name]</i>

<b>2- Direction Control</b>

To change direction of the vehicle you should say so:

Rotate [<i>any_number_between_0-10000</i>] to [<i>left</i> or <i>right</i>]

This will rotate direction of the vehicle in specified degree and way.

<b>3- Horn Control</b>

The command <i>Hoot</i>, sounds the horn until you say <i>Silence the horn</i> .

Also you can specify how long it will be sounded by:

Sound the horn for [<i>any_number_between_0-10000</i>] seconds

<b>4- Driving Vehicle with Voice</b>

The vehicle can go for a time which is specified by user in a fixed speed with the following command:

Go for [<i>any_number_between_0-10000</i>] seconds

The vehicle can go during specified time,however, it is not supported driving vehicle to the specified distant by voice,yet.

Also, brakes can be applied by saying <i>Brake</i> but works are continuing on this command.

<b>NOTE:</b> Any contribution and advice, tiny or significant, wil be highly regarded.
