## Basic information / FAQ

- This tool is not interacting in any way with eve online directly. It is just monitoring and reading log files written by the eve online client.
- It is not and cannot detect if enemies or bad persons enter the current system.
- It can only notify you on chat messages - there is no possibility to get notified if you change e.g. the system or someone enters your system.

## What it does

By starting the tool, it starts to monitor your chat channels. If in any chat your complete pilot name is written, you get some notifications about that. You do not need to add an api key or something else. All you need ist a started eve client (compatible to multi clients).

## Notifications

It is always going to notify you with the default windows notification method in the lower right of your screen. Optional you can open the tool and enter a full path to a sound file. If the file is valid it plays it in addition to the screen notification.

To modify the settings you have to press twice on the program icon next to your clock:

![](https://raw.githubusercontent.com/MyUncleSam/EveChatNotifier/master/EveChatNotifier/Screenshots/NotifyIcon.png)

And how does the Notification looks like?

![](https://raw.githubusercontent.com/MyUncleSam/EveChatNotifier/master/EveChatNotifier/Screenshots/Toast.png)

Or you can play a sound file - depends on you :-).

## Close the program

Just open the context menu on the icon shown above (right mouse button) and choose "Exit".

## Change settings

Since version 2.0.0.0 there is a complete rewritten settings editor. You can open it by double click on the icon or opening the context menu -> Settings. If you want to know more about a setting you just need to hover the text in front of the setting and there will be some help in the footer:

![](https://raw.githubusercontent.com/MyUncleSam/EveChatNotifier/master/EveChatNotifier/Screenshots/Settings.png)

## Custom properties

These settings should only be set if you know what you are doing!

You can change some general properties by modifying the `EveChatNotifier.exe.config` inside the folder of the program itself.

You can change the default path to the eve log files modifying this property. Adding `%DOCUMENTS%` in the text is going to be replaced with the current users document folder.

<table id="bkmrk-setting-name-descrip">

<tbody>

<tr>

<td>**Setting name**</td>

<td>**Description**</td>

</tr>

<tr>

<td>UseRegex</td>

<td>It can be switched to use regular expression. Be careful, this is slower then the default logic! Should only be used if there is a new log format and there is no update currently!</td>

</tr>

<tr>

<td>ChatEntryRegex</td>

<td>

The regex to detect a logline. You need to specify the following groups:

*   senddate: date when the post was sent
*   sender: pilot who sent the message
*   text: the chat tex

</td>

</tr>

<tr>

<td>FileCheckInterval</td>

<td>

If your pc is very slow, please increase this value. The amount set here specifies how often the log files are checked for new entries. A check only retrieves the current filesize and not the content!

</td>

</tr>

<tr>

<td>EnableLogging</td>

<td>

If you want to disable the logging you can turn it off in here. If you do wo please turn it back on if you need support to log error messages!

</td>

</tr>

<tr>

<td>MaxAgeForWatchingLogs</td>

<td>

Only relevant if you do not let the program clean your log folder:

The watcher only checks files where the last change date is X hours old (the setting).

</td>

</tr>

</tbody>

</table>

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

<div class="pcl_tooltip_box" style="display: none;">Image already added</div>
