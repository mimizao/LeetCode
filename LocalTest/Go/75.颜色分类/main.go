package main

func sortColors(nums []int) {
	index0, index2 := 0, len(nums)-1
	for i := 0; i <= index2; {
		if nums[i] == 0 {
			nums[index0], nums[i] = nums[i], nums[index0]
			index0++
			i++
		} else if nums[i] == 2 {
			nums[index2], nums[i] = nums[i], nums[index2]
			index2--
		} else {
			i++
		}
	}
}

func main() {
	nums := []int{2, 0, 1}
	sortColors(nums)
}
