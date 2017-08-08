## Basic information

This tool is not interacting in any way with eve online. It is just monitoring and reading log files written by the eve online client.

It is not and cannot detect if enemies or bad persons enter the current system.

It cannot notify you if the local changes

What it does: if the pilot name is in any chat text it plays a sound (optional) and prints some notification about that.

## What it does

By starting the tool, it starts to monitor your chat channels. If in any chat your complete pilot name is written, you get some notifications about that. You do not need to add an api key or something else. All you need ist a started eve client (compatible to multi clients).

## Notifications

It is always going to notify you with the default windows notification method in the lower right of your screen. Optional you can open the tool and enter a full path to a sound file. If the file is valid it plays it in addition to the screen notification.

To modify the settings you have to press twice on the program icon next to your clock:

![](https://book.esn.space/uploads/images/gallery/2017-08-Aug/scaled-840-0/image-1502048228262.png)

And how does the Notification looks like?

![](https://book.esn.space/uploads/images/gallery/2017-08-Aug/scaled-840-0/image-1502141592601.png)

Or you can play a sound file - depends on you :-).

## Close the program

Just open the context menu on the icon shown above (right mouse button) and choose "Exit".

## Change settings

Since version 2.0.0.0 there is a complete rewritten settings editor. You can open it by double click on the icon or opening the context menu -> Settings. If you want to know more about a setting you just need to hover the text in front of the setting and there will be some help in the footer:

![](https://book.esn.space/uploads/images/gallery/2017-08-Aug/scaled-840-0/image-1502229407705.png)

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

Apache License 2.0: [https://choosealicense.com/licenses/apache-2.0/](https://choosealicense.com/licenses/apache-2.0/)

### Warranty

I, the author, am not responsible in any cases for this software. But as always it is written without any advertising, malware or any other parts which are not needed for this functionality. This software is also not sending any information to anyone.

If you don't trust me you can take a look into the source code.

## Changelog

[https://github.com/MyUncleSam/EveChatNotifier/commits/master](https://github.com/MyUncleSam/EveChatNotifier/commits/master)

<div class="pcl_tooltip_box" style="display: none;">Image already added</div>
