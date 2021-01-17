package main

import (
	"fmt"
)

func main() {
	// Case 1.
	fmt.Println("Case 1. --------------------")
	for x := 0; x < 3; x++ {
		fmt.Println(x)
	}

	// undefined: x
	//x = 2021

	// Case 2.
	fmt.Println("Case 2. --------------------")
	y := 0
	for y < 3 {
		fmt.Println(y)
		y++
	}

	// Case 3. break
	fmt.Println("Case 3. --------------------")
	for x := 0; x < 3; x++ {
		if x > 1 {
			break
		}

		fmt.Println(x)
	}

	// Case 4. continue
	fmt.Println("Case 4. --------------------")
	for x := 0; x < 3; x++ {
		if x < 2 {
			continue
		}

		fmt.Println(x)
	}
}
