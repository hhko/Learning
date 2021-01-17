package main

import (
	"bufio"
	"fmt"
	"os"
	"strings"
)

func main() {
	reader := bufio.NewReader(os.Stdin)

	// // err declared but not used
	// input, err := reader.ReadString('\n')

	input, _ := reader.ReadString('\n')
	input = strings.TrimSpace(input) // 줄 바꿈 문자를 제거한다.

	fmt.Println(input)
}
