import { editor, languages } from 'monaco-editor/esm/vs/editor/editor.api';
import { IEditorContext } from './IEditorContext';
import './languages/json'

// Initialise the Monaco Environment with the relative URL.
// @ts-ignore
// self.MonacoEnvironment = {
//     getWorkerUrl: function (moduleId, label) {
//         return "dist/editor.worker.bundle.js";
//     }
// };

export class Editor {

    private editors: { [id: string]: IEditorContext } = {};

    createEditor(id: string, container: HTMLElement) {

        var newEditor = editor.create(container,
            {
                minimap: {
                    enabled: false
                },
                fontSize: 12,
                contextmenu: false,
                lineNumbersMinChars: 3,
                language: 'application/json',
            });

        var editorContext: IEditorContext = {
            id: id,
            codeEditor: newEditor,
            updating: false
        };

        this.editors[id] = editorContext;
    }
}

export function registerInterop(parentInterop: any) {
    parentInterop['editor'] = new Editor();
}
