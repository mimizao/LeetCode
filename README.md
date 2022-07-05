# Leetcode

如果可以的话，就坚持下去吧

以下内容仅为自己的一些随笔感想，并非题解

## 1.两数之和

这题没有什么要说的，其实就是用空间换时间

## 2.两数相加

关于这题，我最开始想的是一种很笨的方法，就是我把链表先倒过来转成数组，然后再把两个数组相加，然后再把这个数组转成链表，后来呢尝试了一下，发现太复杂了， 不过这个思路应该还是对的，不过确实太麻烦了。  
后来沉下心想了一下，发现其实每次都是只要考虑当前位置的就行了，后面的对与当前的节点只是Next，自然也就可以用递归了。
这是自己第一次用递归解出来链表类的问题，所以还是挺开心的。继续坚持

## 3.无重复字符的最长子串

关于这题，其实最开始看到就是有思路的，但是后面真写的时候发现还是有些地方没有考虑到的

1. 关于`right`应该在满足什么条件下右移，这个卡了一下。最开始我还想用一个切片还存储当前满足条件的子串，后来发现是多么的愚蠢，因为这样的话我每次去判断在当前子串是否有`string[right]`以及对于后续的处理都会非常的麻烦
2. 关于`left`应该什么情况下右移，这里卡了比较长的时间。我最开始并没有考虑到需要判断当前`map`中`string[right]`的index和`left`的情况，只是想着如果有的map中有`string[right]`就直接把`left`挪到`index`就行了，这样实际会有可能把`left`往左移的，所以还是需要判断`index`和`left`的情况的；另外就是`left`和`index`判断的时候，最开始是`left=index`的，也是没有考虑完全，其实是需要`left=index+1`的。

## 4.寻找两个正序数组的中位数

这题在看到时间复杂度要求是O(log(m+n))的时候，是想过用二分法的，但是后续就没有思路了。  
关于题解中给出的方法，这里说一下自己的理解过程，所谓中位数就是找到合并后的数组的第K个数，但是又不能真的合并了之后再去找，所以题解中的方法是从AB两个数组中每次删除K/2个数，同时需要比较AB数组中哪个更小，因为小的那个肯定是不满足条件的，但是大的那个数组就可能删过了。

```go
func findMedianSortedArrays(nums1 []int, nums2 []int) float64 {
	totalLength := len(nums1) + len(nums2)
	if totalLength%2 == 1 {
		midIndex := totalLength / 2
		return float64(getKthElement(nums1, nums2, midIndex+1))
	} else {
		midIndex1, midIndex2 := totalLength/2-1, totalLength/2
		return float64(getKthElement(nums1, nums2, midIndex1+1)+getKthElement(nums1, nums2, midIndex2+1)) / 2.0
	}
}

func getKthElement(nums1, nums2 []int, k int) int {
	index1, index2 := 0, 0
	for {
		if index1 == len(nums1) {
			return nums2[index2+k-1]
		}
		if index2 == len(nums2) {
			return nums1[index1+k-1]
		}
		if k == 1 {
			return min(nums1[index1], nums2[index2])
		}
		half := k / 2
		// 有一点不明白的就是这里为什么要加half之后再减1，我尝试改成了min(index1+half, len(nums1)-1)就报错了
		// 明白了，这个是因为我既然要找第K个，那么AB两个前面必须都是K/2-1个，如果都是K/2个，那么就不满足第K个元素前面有K个，所以需要-1
		newIndex1 := min(index1+half, len(nums1)) - 1
		newIndex2 := min(index2+half, len(nums2)) - 1
		pivot1, pivot2 := nums1[newIndex1], nums2[newIndex2]
		if pivot1 <= pivot2 {
			// 至于这里为什么需要+1是因为这样的话这样才等于k/2，可以把newIndex1=index1+k/2-1代入(不考虑越界的情况)
			k -= (newIndex1 - index1 + 1)
			// 这里为什么需要再加1，是因为newIndex1这个元素已经被排除了
			index1 = newIndex1 + 1
		} else {
			k -= (newIndex2 - index2 + 1)
			index2 = newIndex2 + 1
		}
	}
}

func min(x, y int) int {
	if x < y {
		return x
	}
	return y
}
```
## 5.最长回文子串
这题最开始也能想到把问题才小往大走，但是不知道原来这种做法叫做动态规划，这个有一个很重要的特点是会用空间换时间，也就是这里把最初的状态都记录下来：
```go
            var dp [1000][1000]bool
            for i := range s {
                dp[i][i] = true
            }
```

以及后续的这里，可以看到状态都被记录下来了。

```go
			if s[left] != s[right] {
				dp[left][right] = false
			} else {
				if right-left < 3 {
					dp[left][right] = true
				} else {
					dp[left][right] = dp[left+1][right-1]
				}
			}
```

然后就是才小往大依次走就可以了，需要注意的下的是go写多了，不会写C#了，放下C#的二维数组

```c#
        bool[,] dp = new bool[len, len];
        for (int i = 0; i < len; i++)
        {
            dp[i,i] = true;
        }
```

