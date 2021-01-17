package main

import (
	"fmt"
	"math"
	"strings"
	// "fmt"     // fmt.Println	: 콘솔 출력
	// "math"    // math.Floor		: 내림한 값을 반환한다.
	// "strings" // strings.Title	: 각 단어의 첫 문자를 대문자로 변환한 새로운 만주열을 반환한다.
)

func main() {
	fmt.Println(math.Floor(2.75))
	fmt.Println(strings.Title("csharp developers for golang"))
}

// 출력
// 2
// Csharp Developers For Golang
