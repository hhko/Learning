package main

import "fmt"

func main() {
	x, y, msg := doSomething(1, 2)
	fmt.Println(x, y, msg)
}

// int 타입 정의를 축소 시킬 수 있다.
//func doSomething(x int, y int) (int, int, string) {
func doSomething(x, y int) (int, int, string) {
	return x + 1, y + 2, "hello"
}
