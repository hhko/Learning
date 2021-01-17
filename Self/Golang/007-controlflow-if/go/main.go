package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
)

func main() {
	reader := bufio.NewReader(os.Stdin)
	input, err := reader.ReadString('\n')

	// nill은 NULL을 의미한다.
	if err != nil {
		log.Fatal(err)
	} else { // } else if ... {, } else {
		fmt.Println(input)
	}
}
