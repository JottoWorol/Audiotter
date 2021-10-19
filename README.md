# Audiotter

<img src="https://raw.githubusercontent.com/JottoWorol/Audiotter/main/Logo/audiotter_logo.png" width="30%">

A Unity fast audio integration framework.

Basically, this is just a wrapper on top of basic AudioSource functions, but it provides a few high-level features:
* Pre-defined independent Mixer Groups. You can attach your audio components to either "Sound" or "Music" Mixer Group (channel).
* Per-component volume control
* Independent volume control for each of pre-defined Mixer Groups during runtime
* Master volume control
* Custom Mixer Group assignment
* OnAwake playback
* Delayed playback
* 4 configured components for playback
  - OneShot
  - Random OneShot
  - Loop
  - Random Loop


## Installation
### Option 1
- Open Package Manager through Window/Package Manager
- Click "+" and choose "Add package from git URL..."
- Insert the URL: https://github.com/JottoWorol/Audiotter.git

### Option 2  
Add the following line to `Packages/manifest.json`:
```
"com.jottoworol.audiotter": "https://github.com/JottoWorol/Audiotter.git",
```

## Usage

Right after the installation, Audiotter copies its settings to Assets/Resource folder and the package is ready to use.

To add audio to your game just add one of Audiotter's components. They are lying inside Audiotter/Players menu
[](Screenshots/component_adding.png)
[](Screenshots/component_list.png)

### Example of a component added to GameObject
[](Screenshots/component_example.png)


### Volume control during runtime
The range is [0,1] everywhere.

If MasterVolume is 0.5 and MusicVolume is 0.5, then the resulting volume is 0.25. The same applies to playback components.

All playback component classes inherit ```AudiotterPlayerBase```.
```c#
AudiotterMixer.MasterVolume = .9f;
AudiotterMixer.MusicVolume = .6f;
AudiotterMixer.SoundVolume = .8f;

GetComponent<AudiotterPlayerBase>().Volume = .9f;
GetComponent<AudiotterLoop>().Volume = .9f;
GetComponent<AudiotterRandomLoop>().Volume = .9f;
```
