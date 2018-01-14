## Basic information / FAQ

- This tool is not interacting in any way with eve online directly. It is just monitoring and reading log files written by the eve online client.
- It can only notify for chat messages you receive during playing!
- There is no way to detect something like someone enters your system or something else - only chat messages :-)
- Like every free or open source software: use at your own risk.

## What it does

By starting the tool, it starts to monitor your chat channels. If in any chat your complete pilot name is written, you get some notifications about that. You do not need to add an api key or something else. All you need ist a started eve client (compatible to multi clients).

## Notifications

It is always going to notify you with the default windows notification method in the lower right of your screen. Optional you can open the tool and enter a full path to a sound file. If the file is valid it plays it in addition to the screen notification.

To modify the settings you have to press twice on the program icon next to your clock:

![](https://raw.githubusercontent.com/MyUncleSam/EveChatNotifier/master/EveChatNotifier/Screenshots/NotifyIcon.png)

And how does the Notification looks like?

![](https://raw.githubusercontent.com/MyUncleSam/EveChatNotifier/master/EveChatNotifier/Screenshots/Toast.png)
(Colors can be changed using the properties - see Change settings below.)

Or you can play a sound file - depends on you :-).

## Close the program

Just open the context menu on the icon shown above (right mouse button) and choose "Exit".

## Autostart information

Since version 2.7.0.0 there is a built in autostart function. You can enable it at the properties page. Be sure to remove any other autostart entries which have been set manually.
The autostart is done using the windows scheduler function (logon trigger). Choosing this option has a lot of benefits. Some are:
- If autostart is disabled the exe is not called at all, so no performance issues here.
- This option can be managed easier by code.
- No ugly registry settings needed.
- Can be viewed by the user opening the windows scheduler manager (is inside the root folder called "EveChatNotifier AutoStart").

## Auto updater

Introduced as beta feature with version 2.7.1.0. This function should be able to update your EveChatNotifier with one click. Currently this function is still in beta phase, so please report any errors using the Issue page: https://github.com/MyUncleSam/EveChatNotifier/issues

## Performance

Eve creates daily new chat log files. So if you are playing regular there could be a lot of chat files in your log folder. As this tool needs to monitor this files this coul lead into heavy CPU and HDD usage. To avoid that you can try:

Option | Benefit
------ | -------
**HIGHLY RECOMMENDED:**<br />Switching the move log function on inside the settings UI | Huge performance boost because only the active logs needs to be checked.
Increasing `FileCHeckInterval` | Files are checked not as often - this delays the notification
Increasing `EveChatLogCheckInterval` | Folder with log files are not checked frequently - needs more time to start watching of new log files (new group, conversation, chat, ...)

## Change settings

Since version 2.0.0.0 there is a complete rewritten settings editor. You can open it by double click on the icon or opening the context menu -> Settings. If you want to know more about a setting you just need to hover the text in front of the setting and there will be some help in the footer:

![](https://raw.githubusercontent.com/MyUncleSam/EveChatNotifier/master/EveChatNotifier/Screenshots/Settings.png)

## Custom properties

These settings should only be set if you know what you are doing!

You can change some general properties by modifying the `EveChatNotifier.exe.config` inside the folder of the program itself. Keep in mind, that all properties are only loaded on program start. So you have to restart if you made changes to this file.

Setting name | Description
------------ | -----------
UseRegex | It can be switched to use regular expression. Be careful, this is slower then the default logic! Should only be used if there is a new log format and there is no update currently!
ChatEntryRegex | The regex to detect a logline. You need to specify the following groups:<br />- senddate: date when the post was sent<br/>- sender: pilot who sent the message<br />- text: the chat tex
EveChatLogCheckInterval | Interval of seconds to scan for new log files (which can appear if you enter a new chat, conversation or group)
FileCheckInterval | If your pc is very slow, please increase this value. The amount set here specifies how often the log files are checked for new entries. A check only retrieves the current filesize and not the content!
EnableLogging | If you want to disable the logging you can turn it off in here. If you do wo please turn it back on if you need support to log error messages!
MaxAgeForWatchingLogs | Only relevant if you do not let the program clean your log folder: The watcher only checks files where the last change date is X hours old (the setting).
ToastDelay | How many seconds the default toast notification should stay before it disappears
LogAllMessages | Logs into the program all detected chat messages (just for debugging purpose)
Toast...Color | All possible color settings can be modified using default .net color names which can be found e.g. here: http://yorktown.cbe.wwu.edu/sandvig/shared/netcolors.aspx (only names are suppoerted)
ToastSize | The size of the popup (width; height) - default is 400; 100

## Download

See release page of github project: [https://github.com/MyUncleSam/EveChatNotifier/releases](https://github.com/MyUncleSam/EveChatNotifier/releases)

## Requirements

*   Windows (not tested on other systems - but I think it is not going to work on non Windows systems)
*   .Net Framework 4.0
*   Enabled logging in the eve client (Settings -> chat -> chat -> log to file)

## License and warranty

### License

MIT license: [https://tldrlegal.com/license/mit-license#fulltext](https://tldrlegal.com/license/mit-license#fulltext)

The MIT License (MIT)

Copyright (c) 2017 Stefan Ruepp

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

## Changelog

[https://github.com/MyUncleSam/EveChatNotifier/commits/master](https://github.com/MyUncleSam/EveChatNotifier/commits/master)


## Support

If you wanna support my work feel free to donate ISK ingame to "Wolf Tongue".
