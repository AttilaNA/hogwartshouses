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

### *Erado Locus!*

While playing around with the Locus Novus spell, a few misplaced rooms have popped up accidentally, and now they block some corridors. We need a reverse spell to unmake a room.

1. The room with the specified ID is deleted when calling the <span style="color: yellow">/rooms/{roomID}</span> endpoint with the DELETE method.

### *Renovo Locus!*

Some rooms require a bit of renovation, as they have become old, messy, and ugly over the centuries of usage.

1. The room with the specified ID is updated when calling the <span style="color: yellow">/rooms/{roomId}</span> endpoint with the PUT method.

### *The list of students*

Hermione Granger and Draco Malfoy have just arrived at Hogwarts. As long as they are not on the list of the students, Filch will not allow them to enter. Put them on the list, so they can enter before the dinner is over.

1. Two student entities are stored in the application memory.

### *New rooms for students*

Dinner's over, time for bed. But wait, which one? Hermione and Draco aren't assigned to their new rooms yet! Help them find their new rooms (separate, of course).

1. At least two empty rooms are stored in the application memory.
2. Hermione and Draco are assigned to separate rooms.

### *Play around*

Add some functionality to the server.

1. Assign student to room.
2. Remove student from room.
3. List all available rooms.
4. Remove stundent from hostel.
5. Update name of student.

