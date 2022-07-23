# LeetCode

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

## 6.z-字形变换

这题自己最开始想到了第三种解法，就是按照最终的行，然后把一行一行拼起来，但是自己没有想到还能把每一行都分成很多周期  
还有说下第二个循环那里为啥是`j+i<len`，因为这里的判断条件`j+i`就可以理解成当前节点

## 7.整数反转

关于这题最开始又是非常的愚蠢，想着先转成字符串，然后再转回来那种写法，确实是太愚蠢了。  
确实像题解里面的那个，我只要每次取得最后一个数就行了，就是判断是否越界的时候，不能在得到了新的数之后再去判断，要在这之前。说下题解中那个简单的判断是否越界的，那个是先算出来数之后再判断，根据是Java在越界后会强制设置为最大值/最小值，这里并不是对所有的语言都适用，需要注意。

## 8.整数反转

这题基本都是自己的思路吧，就是要考虑的情况有点多，尤其是那个中间有空格的情况，我原本以为这种会直接跳过空格继续找呢，结果官方的意思是需要直接返回，算是我理解不到位的一个地方吧。  
还有就是自己的rust水平，又忘的差不多了，系统的看了下字符串相关的知识，一定要记住String类型实际就是一个`Vec<u8>`，是一个utf-8类型的动态数组，至于那个&str就是切片，所以用索引例如`s[0]`这种实际访问并不一定能对应到一个有效的Unicode标量值，所以会报错，目前常用的操作如下

```rust
fn main() {
    let s = String::from("中国人");
	// 这里其实是可以看到c的类型是char，可以正确的输出中国人
    for c in s.chars() {
        println!("{}", c);
    }
	// 这里b的类型就是u8，所以输出的都是数字
    for b in s.bytes() {
        println!("{}", b);
    }
}
```

至于`collect`是将一个迭代器迭代的所有元素组合成一个新的集合，所以很多题目里面会有`s.chars().collect()`，就是将这个字符串转换过来成其他语言可以直接遍历的那种形式。

## 9.回文数

这题没有什么好说的，就是自己的笨方法转换成字符串然后再操作，其实复杂度还好

官方的解题方法是一种比较巧妙的可以把数字倒过来的办法，不过是只倒一半，不错不错

至于最后的`x == reverted_number || x == reverted_number / 10`这里前面没有什么说的，是偶数的情况，后面呢就是奇数的情况，不用考虑最后那个数字，这里还是比较巧妙的

## 10.正则表达式匹配

首先恭喜下自己，能想到这种题应该用动态规划了，虽然还是没有做出来  
其次说下和官方题目理解不一致的地方，官方的意思是假设`s = "abcc" p = "abc*"`，是相当于`*`匹配了2次，而不是1次，如果匹配了0次的话，那么`p = "ab"`，这里我感觉我的想法也是说的通的，只是和官方的本意不一致。
说下那个状态转移方程比较难以理解的地方，就是当`p`的最后一个字符是`*`且`s[i]==p[j-1]`的情况，`f[i][j]=f[i-1][j]||f[i][j-2]`，前面的`f[i-1][j]`这里就是就是说的，我直接把`s[i]`舍弃掉，接着往前走就行了，后面那个或者`f[i][j-2]`的意思就是说，虽然`s[i]==p[j-1]`但是我也可以匹配0个，这两个只要有一个满足就行了，算是勉强理解了吧。

## 11.盛最多水的容器

昨天被第10题吊打了之后，晚上看了一下这题，果然早上就有思路了。  
这题最开始基本都能想到将两个坐标一个设置为0,一个设置为len-1，但是如何缩小这个范围， 也就是究竟是`left++`还是`right--`是一个非常需要考虑的问题，能想明白谁小就动谁就行了，因为只有动小的新面积才有可能更大，如果是动大的，新面积肯定小于等于现在的面积(因为小的限制了高，并且长变小了1)。

## 12.整数转罗马数字

首先说下这题自己写出来也是没有问题，时间复杂度也还好，就是有点繁琐  
关于题解的贪心法，自己刚开始也想到了，但是没有想到的这么巧妙，所以还是要多练习啊，加油。

## 13.罗马数字转整数

基本都是自己的思路吧，还没有看题解，我觉得我的这个复杂度已经不错了，哈哈  
Rust还是得练习啊，太菜了。

## 14.最长公共前缀

这题也是自己的想法就不错，没有看答案，哪天无聊再看看答案吧，应该也不能比我的更简洁了。

## 15.三数之和

这题自己刚开始还想着把先走一遍遍历把数字放到map中，然后再像第一题那样，后来发现很难实现。  
关于题解中需要理解的地方  
1. 排序之后如何去除重复的数是难点，也就是题解中的如果和前面一个数相等就继续走。
2. `third--`之后为什么在之后`second`的循环中不再设置为`len-1`？因为此时的数组已经是排序后的数组，`second++`之后，满足条件的`third`肯定是小于等于上次循环的`third`的，所以也就不需要再`third = len-1`

## 16.最接近的三数之和

这题虽然最终的排名不行，但是自己的思路是完全正确的，复杂度也没有问题  
说下自己当时写的时候不周到的地方，就是在确定了`first`的情况下，究竟是应该走`second`还是`third`的问题，最初的想法是谁变动下就动谁，这个是完全错误的  
正确的确实是应该像后面写的那样，如果`tempRes < target`，就说明现在的结果还是太小了，应该让`second++`；同理如果`tempRes > target`，说明现在的值太大了，应该`third--`。

## 17.电话号码的字母组合

自己的想法问题也不大，只是没有这么优雅，也不知道这种方法叫做回溯法，并且这题的情况特殊，是并不需要提前返回的。  
另外就是自己的Rust水平是真的烂啊，稍微复杂一点的情况就都写不了了，真是个弟弟。

## 18.四数之和

还是先排序，然后要注意什么情况下可以接着走，还有就是如果答案正好的时候`left`和`right`应该怎么走，这两个数还是应该继续往中间走，因为中间还是有可能满足的情况的。  
不过这题简直就是坑爹啊，本来难度也不是很难，做法和那个三数之和也有点类似，虽然还是看了下官方的题解，但是也差不多算掌握了，但是这个越界真的是把人折磨疯了，不知道有什么意义。

## 19.删除链表的倒数第 N 个结点

没什么说的，先计算下数量，然后倒过来删除就行了，就是需要注意下坐标。
文思泉涌，很快哈

## 20.有效的括号

自己的想法就是去实现一个栈，还想着如果可以的话用数字操作可能会更快，实际上并没有。另外以往自己写的Rust代码都没有体现Rust的风格，这次模仿着别人写的，以后尽量往这个上面靠拢。

```rust
fn main() {
    let s = String::from("([)]");
    let res = is_valid(s);
    println!("{}", res);
}

fn is_valid(s: String) -> bool {
    if s.len() % 2 == 1 {
        return false;
    }
    let mut stack: Vec<char> = vec![];
    for c in s.chars() {
        match c {
            '(' | '[' | '{' => stack.push(c),
            ')' => {
                if stack.len() == 0 || stack.pop().unwrap() != '(' {
                    return false;
                }
            }
            ']' => {
                if stack.len() == 0 || stack.pop().unwrap() != '[' {
                    return false;
                }
            }
            '}' => {
                if stack.len() == 0 || stack.pop().unwrap() != '{' {
                    return false;
                }
            }
            _ => (),
        }
    }
    stack.len() == 0
}
```

##  21.合并两个有序链表

自己的方法就是属于一直写，不够简洁，用递归的话确实就比较简单。另外Rust抄了一个别人的代码，看起来真的很好看。

```rust
impl Solution {
    pub fn merge_two_lists(
        list1: Option<Box<ListNode>>,
        list2: Option<Box<ListNode>>,
    ) -> Option<Box<ListNode>> {
        match (list1, list2) {
            (Some(n1), Some(n2)) => {
                if n1.val <= n2.val {
                    Some(Box::new(ListNode {
                        val: n1.val,
                        next: Solution::merge_two_lists(n1.next, Some(n2)),
                    }))
                } else {
                    Some(Box::new(ListNode {
                        val: n2.val,
                        next: Solution::merge_two_lists(Some(n1), n2.next),
                    }))
                }
            }
            (Some(n1), None) => Some(n1),
            (None, Some(n2)) => Some(n2),
            _ => None,
        }
    }
}
```

## 22.括号生成

这题自己原本写的是`res = () + res || (res) || res + ()`，这样把这三个再拼成一个结果，然后再去重就行了，实际上自己是多么的愚蠢啊，这样会少一些情况，例如`res = (())()`，后面会有`res = (())()()`这种情况，就是插在了中间，所以就少考虑情况了。

放下别人的**深度优先规划**的解法

![](https://s2.loli.net/2022/07/22/1joCyiQz6WvB37L.png)

```go
func generateParenthesis(n int) []string {
	var res []string
	generate(&res, "", 0, 0, n)
	return res
}

func generate(res *[]string, str string, leftCount, rightCount, n int) {
	if leftCount > n || rightCount > n || rightCount > leftCount {
		return
	}
	if leftCount == n && rightCount == n {
		*res = append(*res, str)
	}
	generate(res, str+"(", leftCount+1, rightCount, n)
	generate(res, str+")", leftCount, rightCount+1, n)
}
```

## 23.合并k个升序链表

这题看到的第一时间就想到了第21题的两个有序链表，也确实可以那样做，就是两个两个合成，最终再返回就可以了。结果可以说是惨不忍睹，只击败了8%的兄弟。

痛，太痛了，改，改成不是两个两个合并的，是所有的一块合并，结果还是只击败了13%的人，还是看看大佬的吧。

看了下官方的题解，第一种其实和我的一样，就是挨个合成，说下第二种**分治合并**

首先看下这个图，其实看下这个图就基本清楚了，其实就是在合并的时候不要再依次往后对比了，而是应该一直两个两个分，其实也就是二分的概念。

![](https://s2.loli.net/2022/07/23/wrMB4ehPYJTCNEV.png)

```go
func mergeKLists(lists []*ListNode) *ListNode {
	return merge(lists, 0, len(lists)-1)
}

func merge(lists []*ListNode, left, right int) *ListNode {
	if left == right {
		return lists[left]
	}
	if left > right {
		return nil
	}
	mid := (left + right) / 2
	return newMergeTwoLists(merge(lists, left, mid), merge(lists, mid+1, right))
}

func newMergeTwoLists(list1 *ListNode, list2 *ListNode) *ListNode {
	if list1 == nil {
		return list2
	} else if list2 == nil {
		return list1
	} else if list1.Val <= list2.Val {
		list1.Next = newMergeTwoLists(list1.Next, list2)
		return list1
	} else {
		list2.Next = newMergeTwoLists(list1, list2.Next)
		return list2
	}
}
```

这里放下根据这种思想写的`go`代码
