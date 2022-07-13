/*
 * @lc app=leetcode.cn id=12 lang=golang
 *
 * [12] 整数转罗马数字
 */
package main

// @lc code=start
func intToRoman(num int) string {
	var res = ""
	if num >= 1000 {
		count := num / 1000
		var tempStr = ""
		for i := 1; i <= count; i++ {
			tempStr += "M"
		}
		res += tempStr
		num -= 1000 * count
	}
	if num >= 100 {
		var tempStr = ""
		count := num / 100
		switch {
		case count < 4:
			for i := 1; i <= count; i++ {
				tempStr += "C"
			}
		case count == 4:
			tempStr = "CD"
		case count == 5:
			tempStr = "D"
		case count > 5 && count < 9:
			tempStr = "D"
			for i := 1; i <= count-5; i++ {
				tempStr += "C"
			}
		case count == 9:
			tempStr = "CM"
		}
		res += tempStr
		num -= 100 * count
	}
	if num >= 10 {
		var tempStr = ""
		count := num / 10
		switch {
		case count < 4:
			for i := 1; i <= count; i++ {
				tempStr += "X"
			}
		case count == 4:
			tempStr = "XL"
		case count == 5:
			tempStr = "L"
		case count > 5 && count < 9:
			tempStr = "L"
			for i := 1; i <= count-5; i++ {
				tempStr += "X"
			}
		case count == 9:
			tempStr = "XC"
		}
		res += tempStr
		num -= 10 * count
	}
	if num >= 0 {
		var tempStr = ""
		count := num
		switch {
		case count < 4:
			for i := 1; i <= count; i++ {
				tempStr += "I"
			}
		case count == 4:
			tempStr = "IV"
		case count == 5:
			tempStr = "V"
		case count > 5 && count < 9:
			tempStr = "V"
			for i := 1; i <= count-5; i++ {
				tempStr += "I"
			}
		case count == 9:
			tempStr = "IX"
		}
		res += tempStr
	}
	return res
}

// @lc code=end
