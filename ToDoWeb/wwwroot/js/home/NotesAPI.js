export default class NotesAPI {
 

    static async getAllNotes() {
        let response = await fetch("http://localhost:5000/home/items");
        const notes = await response.json();

        return notes;
    }

    static async saveNote(noteToSave) {

        await fetch("http://localhost:5000/home/update", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(noteToSave)
        })
            .catch(error => console.log("Save error"))

       
    }

    static async createNote(noteToSave) {

        await fetch("http://localhost:5000/home/create", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(noteToSave)
        })
            .catch(error => console.log("Create error"))


    }

    static async deleteNote(id) {
        await fetch("http://localhost:5000/home/delete", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(id)
        })
            .catch(error => console.log("Delete error"))
    }
}
