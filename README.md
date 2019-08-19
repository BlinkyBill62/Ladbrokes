# Ladbrokes
This project is a test project for Ladbrokes

This project takes a list of integers representing the codename of the spy and checks it against a list of integers which represents a message. For a message to be valid it must contain all elements of the code name within the message and they are in the same order as codename within the message.

There are two projects within this project. The first is the API for checking codename within the message and this is contained in the Ladbrokes folder. The second is UnitTest for the API which contains tests to check a codename against a message and empty codename. The UnitTests are contained in /Ladbrokes.UnitTest.

If the API finds a codename in a message it will return a true result. If the codename is not in the message or there is an empty codename it will return a false result.
