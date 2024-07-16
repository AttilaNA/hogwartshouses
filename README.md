# Hogwarts Houses

## Goal of the project

* Build Web APIs in ASP.NET.
* Understand the Controller-Service-Repository design pattern.

## Tasks

### *Locus Omnis!*

Dumbledore tasked prof. McGonagall with writing a list of all rooms on a piece of parchment. The deadline is tomorrow, so she needs your help.

1. A list of all rooms is returned when calling the <span style="color: yellow">/rooms</span> endpoint with the GET method.

### *Invenio Locus!*

"Keep an eye on the staircases. They like to change." This turned out to be correct, which makes it really easy to get lost. Poor Luna just got lost in the building and the only thing she remembers is the room number. Help Luna find her room by its number.

1. The room with the specified ID is returned when calling the <span style="color: yellow">/rooms/{roomId}</span> endpoint with the GET method.

### *Locus Novus!*

By some magical accident, Hogwarts is completely out of rooms! We need to create some new empty rooms, so that the students have a place to live. A room should be big enough for more than one student.

1. A new room can be added when calling the <span style="color: yellow">/rooms</span> endpoint with the POST method.