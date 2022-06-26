import editor = require('./Components/Editor/JS/Editor');

var appInterop = {
}

editor.registerInterop(appInterop);

window["mockaco"] = {
    gui: appInterop
}
