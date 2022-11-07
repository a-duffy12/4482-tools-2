# 4482-tools-2
 
The Localization Window is the nexus of the translation and localization tool. It can be accessed under Window > Localization. It contains a series of text input boxes and buttons.

Key Functions deal with the translation keys. These are assocaited with no language. The Add Key button adds a new key, and the Remove Key button removes an existing key. Both will fail if the key already exists (add) or does not exist (remove).

Language Functions deal with the language values themselves. The Add Language button adds a new language, and the Remove Language button removes an existing language. Both will fail if the language already exists (add) or does not exist (remove).

Set Active Language sets the active language of the game that will be displayed. This is defaulted to english. If the language value it is being set to is not a language present, it will fail. This is visible during runtime as well.

Below is a table with all the keys and their translations. Each Key is laid out in a row, with each language having a column. Adding and removing keys and languages will update this in real-time. To have the translations be updated in the game itself during runtime, click the button below it, Refresh Translations.

During runtime, there are 6 text boxes displaying the values of the translations. If the key does not exist, then it will simply say KEY X. Only the first 6 keys that are present will be displayed.
