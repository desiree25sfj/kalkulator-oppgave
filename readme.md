## Flowchart (text version)

1. Start program
2. Start loop
	- Display menu ("Choose operation: add, subtract, multiply, divide, type exit to quit")
3. Read input
	- Check for "exit" -> Goodbye
4. Ask for numbers
 	- Read user input as string
	- Split the string to create an array of number strings
5. Convert input
	- from string to double
	- Store numbers in a list or array
6. Decide between overloads
	- Two numbers -> call the overload that takes to doubles
	- More numbers -> call the overload that takes a list or array of doubles
7. Perform calculation and store the result
8. Display the result
9. Loop back
10. End

## Flowchart (Excalidraw)
![Flowchart](/images/flowchart.png)

## Pseudocode
```
START PROGRAM

Welcoming message: "Welcome to the Overloaded Calculator!"

Repeat forever:
1. SHOW message: "Choose operation: add/subtract/multiply/divide (or type EXIT to quit)"
2. READ the user's choice -> call it operation
	- IF user typed EXIT
		- "Goodbye!"
		- STOP the loop and END PROGRAM
3. Show message: "Please enter your numbers."
4. READ the user's input -> call it numbersText
5. Split numbersText into separate pieces
6. Convert each piece into a number and put them in a list called numbers
7. IF numbersText == two numbers
	- Call operation with two numbers
	- ELSE IF more than two numbers
		- Call the operation that handles a list
8. Show result
9. Go back to start of the loop

END PROGRAM
``` 