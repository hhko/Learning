package main

import (
	"fmt"
	"reflect"
	"strconv"
)

func main() {
	year := 2021
	length := 1.2

	// Case 1. 숫자 -> 숫자
	// // cannot use year (type int) as type float64 in assignment
	// length = year

	length = float64(year)
	fmt.Println(length, reflect.TypeOf(length))

	// Case 2. 문자열 -> 숫자, ...
	grade, _ := strconv.ParseFloat("3.14", 64) // Float64 : "64"는 결괏값의 정밀도 비트 수
	fmt.Println(grade, reflect.TypeOf(grade))

	// strconv.ParseInt vs. strconv.Atoi
}
