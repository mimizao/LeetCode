package main

import "fmt"

func main() {
	x := 2.00000
	n := 10
	res := myPow(x, n)
	fmt.Println(res)
}

func myPow(x float64, n int) float64 {
	if n >= 0 {
		return myQuickMul(x, n)
	}
	return 1.0 / myQuickMul(x, -n)
}

func quickMul(x float64, n int) float64 {
	if n == 0 {
		return 1
	}
	y := quickMul(x, n/2)
	if n%2 == 0 {
		return y * y
	}
	return y * y * x
}

func myQuickMul(x float64, n int) float64 {
	if n == 0 {
		return 1.00000
	}
	if n == 1 {
		return x
	}
	res := x
	count := 1
	for count <= n/2 {
		res *= res
		count *= 2
	}
	res = res * myQuickMul(x, n-count)
	return res
}
