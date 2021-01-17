package main

import (
	"fmt"
	"reflect"
)

func main() {
	// Case 1.
	var quantity int
	var length, width float64
	var customerName string

	quantity = 2
	customerName = "Damon Cole"

	length, width = 1.2, 2.4

	// Case 2. : 값 할당
	var quantity2 int = 2
	var length2, width2 float64 = 1.2, 2.4
	var customerName2 string = "Damon Cole"

	// Case 3. : 타입 추론
	var quantity3 = 2
	var length3, width3 = 1.2, 2.4
	var customerName3 = "Damon Cole"

	// Case 4. : 단축 변수 선언(short variable declaration)
	quantity4 := 2
	length4, width4 := 1.2, 2.4
	customerName4 := "Damon Cole"

	fmt.Println("Case 1.------------------")
	fmt.Println(quantity, reflect.TypeOf(quantity))
	fmt.Println(length, reflect.TypeOf(length))
	fmt.Println(width, reflect.TypeOf(width))
	fmt.Println(customerName, reflect.TypeOf(customerName))

	fmt.Println("Case 2.------------------")
	fmt.Println(quantity2, reflect.TypeOf(quantity2))
	fmt.Println(length2, reflect.TypeOf(length2))
	fmt.Println(width2, reflect.TypeOf(width2))
	fmt.Println(customerName2, reflect.TypeOf(customerName2))

	fmt.Println("Case 3.------------------")
	fmt.Println(quantity3, reflect.TypeOf(quantity3))
	fmt.Println(length3, reflect.TypeOf(length3))
	fmt.Println(width3, reflect.TypeOf(width3))
	fmt.Println(customerName3, reflect.TypeOf(customerName3))

	fmt.Println("Case 4.------------------")
	fmt.Println(quantity4, reflect.TypeOf(quantity4))
	fmt.Println(length4, reflect.TypeOf(length4))
	fmt.Println(width4, reflect.TypeOf(width4))
	fmt.Println(customerName4, reflect.TypeOf(customerName4))
}
