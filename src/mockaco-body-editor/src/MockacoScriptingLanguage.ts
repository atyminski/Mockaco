import { languages } from 'monaco-editor/esm/vs/editor/editor.api'

// Register a new language
languages.register({ id: 'mockaco-scripting' });

// Register a tokens provider for the language
languages.setMonarchTokensProvider('mockaco-scripting', {
    tokenizer: {
        root: [
            [/\[error.*/, 'custom-error'],
            [/\[notice.*/, 'custom-notice'],
            [/\[info.*/, 'custom-info'],
            [/\[[a-zA-Z 0-9:]+\]/, 'custom-date']
        ]
    }
});
