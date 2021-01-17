package main

import (
	"fmt"
	"reflect"
)

func main() {
	fmt.Println(reflect.TypeOf(42))     // int
	fmt.Println(reflect.TypeOf(3.1415)) // float64
	fmt.Println(reflect.TypeOf(3.1415F)) // double 
	fmt.Println(reflect.TypeOf(true))                             // bool
	fmt.Println(reflect.TypeOf("Hello C# Developers for Golang")) // string
}
