import NotesView from "./NotesView.js";
import NotesAPI from "./NotesAPI.js";

export default class App {
    constructor(root) {
        this.notes = [];
        this.activeNote = null;
        this.view = new NotesView(root, this._handlers());

        this._refreshNotes();
    }

    async _refreshNotes() {
        const notes = await NotesAPI.getAllNotes();;

        this._setNotes(notes);
        if (notes.length > 0) {
            this._setActiveNote(notes[0]);
        }
    }

    _setNotes(notes) {
        this.notes = notes;
        this.view.updateNoteList(notes);
        this.view.updateNotePreviewVisibility(notes.length > 0);
    }

    _setActiveNote(note) {
        this.activeNote = note;
        this.view.updateActiveNote(note);
    }

    _handlers() {
        return {
            onNoteSelect: noteId => {
                const selectedNote = this.notes.find(note => note.id == noteId);
                this._setActiveNote(selectedNote);
            },
            onNoteAdd: async () => {
                const newNote = {
                    name: "Введите заголовок...",
                    description: "Введите текст..."
                }

                await NotesAPI.createNote(newNote);
                this._refreshNotes();
            },
            onNoteEdit: async (name, description) => {
                await NotesAPI.saveNote({
                    id: this.activeNote.id,
                    name,
                    description
                });

                this._refreshNotes();
            },
            onNoteDelete: async (noteId) => {
                await NotesAPI.deleteNote(noteId);
                this._refreshNotes();
            },
        };
    }
}
