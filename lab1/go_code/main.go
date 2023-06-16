package main

import "bufio"
import "fmt"
import "math/rand"
import "os"
import "strconv"
import "strings"
import "time"


func out(a string) {
  fmt.Println(a)
}

func main() {
    out("Welcome to the guessing game!")
    rand.Seed(time.Now().UnixNano())
    var secretNumber int
    var guesses int
    secretNumber = 15
    var fnum float
    fnum = 15.53
    var boolnum bool
    boolnum = true
    boolnum = false
    const connum = 42
    var numbers [5]int = [5]int{1,2,3,4,5}
    numbers[1] = 42
    var *num2 = &numbers
    for len(guesses) < 10 {
        fmt.Print("Guess a number between 1 and 100: ")
        var guessString, _
        var guess
        _ = reader.ReadString('\n')
        guessString = strings.TrimSpace(guessString)
        guess = strconv.Atoi(guessString)
        var err := guess
        if (err != nil) {
            out("Invalid input. Please enter a valid number.")
            continue
        }
        if (guess < 1) || (guess > 100) {
            out("Your guess is out of range. Please guess a number between 1 and 100.")
            continue
        }
        guesses = append(guesses, guess)
        if (guess == secretNumber) {
            fmt.Printf("Congratulations! You guessed the secret number %d in %d attempts!\n", secretNumber, len(guesses))
            break
        } else if (guess < secretNumber) {
            out("Your guess is too low. Try again.")
        } else {
            out("Your guess is too high. Try again.")
            goto L
        }
        L:
    }
    if (len(guesses) == 10) {
        fmt.Printf("Sorry, you didn't guess the secret number %d in 10 attempts. The secret number was %d.\n", secretNumber, secretNumber)
    }
}