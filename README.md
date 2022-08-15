[toc]

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

## 24.两两交换链表中的节点

还行，也没有什么卡壳的地方，很平稳的做出来了，思路就不写了，估计下次还是能做出来。

## 25.k-个一组翻转链表

这题是一个困难题，不过自己也做出来，而且整体思路和官方题解的差别并不大，都是分为以下几步，先判断剩余的时候满足`k`，如果不满足的话就直接返回，如果满足的话就把剩余的翻转一下，其实自己写的问题就是翻转的过程写的太麻烦了，这里先放下官方的翻转过去，其中`head`和`tail`分别是首节点和尾节点：

```c#
    public ListNode[] MyReverse(ListNode head, ListNode tail)
    {
        ListNode prev = tail.next;
        ListNode p = head;
        while (prev != tail)
        {
            ListNode nex = p.next;
            p.next = prev;
            prev = p;
            p=nex;
        }
        return new ListNode[]{tail,head};
    }
```

关于这个算法，现在脑子已经有点晕了，先记录下，等会再去理解，先看书去了。

## 26.删除有序数组中的重复项

原本的做法是如果`nums[left]==nums[right]`，就去找下一个不相等的`nums[index]`，找到的话就把`ritht--index`都设置为`nums[index]`，后来想了一下，根本没有必要，只需要把`nums[right]`设置为`nums[index]`就可以了。

**注意点一：**在设置了`nums[right]=nums[index]`之后需要注意不能再判断`nums[left]==nums[right]`了，因为有可能会出现`nums[left]>nums[right]`的情况，比如`nums = {1,1,1,2,3,4}`，在第一次判断之后就会变成`nums = {1,2,1,2,3,4}`，所以需要改变判断条件。

**注意点二：**可以提前退出，如果`nums[left]==nums[len-1]`，就是说如果已经是满足条件的`nums`了，就可以提前返回结果了。

这里再说下官方题解，确实比我的巧妙多了：

```rust
    pub fn remove_duplicates(nums: &mut Vec<i32>) -> i32 {
        let len = nums.len();
        if len <= 1 {
            return len as i32;
        }
        let mut slow = 1; // slow是指下一次要更改值的坐标
        let mut fast = 1; // fast是和前面不同的那个值，也就是将slow设置为fast
        while fast < len {
            if nums[fast] != nums[fast - 1] {
                nums[slow] = nums[fast];
                slow += 1;
            }
            fast += 1;
        }
        return slow as i32;
    }
```

## 27.移除元素

其实这题我感觉不排序也可以做出来，不过那样应该比较麻烦，所以采取了排序的做法。

排序后，第一时间想的是采用二分法来找坐标，但是那样找到之后还需要再在附近找下其他坐标，感觉也挺麻烦的，直接依次递增了。

找到坐标后原本是采用确定这个范围，再来一个循环将这个范围内的值替换，后来看了下完全可以直接替换，就是需要退出的条件。

其他的这题就没有什么了，另外放下三种语言的排序，总是忘。

* `C#`：`array.sort(nums)`
* `Go`：`sort.Ints(nums)`
* `Rust`：`nums.sort_unstable()`

 ## 28.实现strStr()

自己的想法其实还行，看看效率什么的都还好，就是需要注意下在`Rust`中因为`haystack_len`和`needle_len`都是`usize`类型，所以在`for i in 0..=haystack_len - needle_len`之前需要判断大小，其他的就没啥了，放下三种语言取子串的区别：

* `C#`：`haystack.Substring(i, needleLength)`，这里的`needleLength`相当于长度
* `Go`：`haystack[i:i+needleLen]`，这里相当于一个开闭区间
* `Rust`：`&haystack[i..(i + needle_len)]`，这里和上面一样，都是一个开闭区间，需要注意下这里已经是`&str`之类的类型的

![](https://s2.loli.net/2022/07/29/fO1z3GIuxkKCsPv.png)

## 29.两数相除

这题最开始的时候自己当去翻了下书，发现书里面并没有讲通过位运算来实现任意的除法，只有2的幂才可以，所以就想自己去写，后来写的时候就写不出来了，说下官方题解的思路。

1. 先解决那些特殊情况
2. 如果`dividend>divisor`，那么这时结果是肯定大于1的，然后这个时候判断`dividend`是否大于`2divisor`，如果还大于就接着找，一直将后面的结果变大，如果超出的话，就用`dividend-2ndivisor`再和`divisor`比较，一直重复这个过程即可。

## 30.串联所有单词的子串

这题对自己还是有点难度的，并没有做出来，自己做的时候想的是直接得出`words`的所有组合，然后再依次的去比较，但是也没有写出来，当然这种方法的复杂度也是非常高的，下面说下自己对于官方题解的理解。

首先放下官方题解的全部内容，理解过程中花了时间的部分在代码中标注：

记 `words` 的长度为 `wordsLen`，`words` 中每个单词的长度为 `wordLen`，`s`的长度为`sLen`。首先需要将`s`划分为单词组，每个单词的大小均为`wordLen`（首尾除外）(虽然我说了有难以理解的地方在下面写，但是官方的这里真的写的很难理解，感觉把这句去掉更容易理解)。这样的划分方法有`wordLen`种，即先删去前`i(i=0~wordLen-1)`个字母后，将剩下的字母进行划分，如果末尾有不到`wordLen`个字母也删去。对这`wordLen`种划分得到的单词数组分别使用滑动窗口对`words`进行类似于「字母异位词」的搜寻。

划分成单词组后，一个窗口包含`sLen`中前`wordsLen`个单词，用一个哈希表`differ`表示窗口中单词频次和`words`中单词频次之差。初始化`differ`时，出现在窗口中的单词，每出现一次，相应的值增加`1`，出现在`words`中的单词，每出现一次，相应的值减少`1`。然后将窗口右移，右侧会加入一个单词，左侧会移出一个单词，并对`differ`做相应的更新。窗口移动时，若出现`differ`中值不为`0`的键的数量为`0`，则表示这个窗口中的单词频次和`words`中单词频次相同，窗口的左端点是一个待求的起始位置。划分的方法有`wordLen`种，做`wordLen`次滑动窗口后，即可找到所有的起始位置。

```c#
    public IList<int> FindSubstring(string s, string[] words)
    {
        int sLen = s.Length;
        int wordsLen = words.Length;
        int wordLen = words[0].Length;
        IList<int> result = new List<int>();
        // 为什么这里是i<wordLen就可以了，是因为下面采用了滑动窗口，所有最初的起点只有0..wordLen-1这些位置就可以了
        // 因为这个原因，所以下面的start每次递增都是wordLen
        for (int i = 0; i < wordLen && i + wordsLen * wordLen <= sLen; i++)
        {
            // differ的作用，differ记录的是滑动窗口和words中每个单词出现的频次差，如果当前的滑动窗口和words中的频次差都为0
            // 那么当前的滑动窗口就是满足条件的，将这个窗口的起点位置记录即可
            Dictionary<string, int> differ = new Dictionary<string, int>();
            // 这里是先确定一个起点为i，大小为wordsLen*wordLen的滑动窗口，并将s中i~i+wordsLen*wordLen的内容都放进differ
            for (int j = 0; j < wordsLen; j++)
            {
                string word = s.Substring(i + j * wordLen, wordLen);
                if (!differ.ContainsKey(word))
                {
                    differ.Add(word, 0);
                }
                differ[word]++;
            }
            // 上一步已经将s中的内容放进去了，我们就可以比对和words中的差别了，如果有的就将这个减1即可
            foreach (string word in words)
            {
                if (!differ.ContainsKey(word))
                {
                    differ.Add(word, 0);
                }
                differ[word]--;
                if (differ[word] == 0)
                {
                    differ.Remove(word);
                }
            }
            // 这里开始滑动这个窗口，每次滑动的步长都是wordLen
            for (int start = i; start < sLen - wordsLen * wordLen + 1; start += wordLen)
            {
                // 因为start是从i开始的，所以这里要排除一下，其实可以再遍历了words之后就先判断i位置是否满足条件的
                if (start != i)
                {
                    // 窗口右滑的时候，右边新进入一个单词，把这个单词加入滑动窗口的differ中
                    // 注意这里是start+(wordsLen-1)*wordLen，并不是start+wordsLen*wordLen
                    // 因为这个时候start已经是i+wordLen了，即start已经不是原滑动窗口的下标了
                    // 而是新的滑动窗口的下标
                    string word = s.Substring(start + (wordsLen - 1) * wordLen, wordLen);
                    if (!differ.ContainsKey(word))
                    {
                        differ.Add(word, 0);
                    }
                    differ[word]++;
                    if (differ[word] == 0)
                    {
                        differ.Remove(word);
                    }
                    // 窗口右滑的时候，左边要出去一个单词，将这个单词从differ中去除
                    // 这里的start-wordLen和上面同理，start是新的滑动窗口的下标
                    word = s.Substring(start - wordLen, wordLen);
                    if (!differ.ContainsKey(word))
                    {
                        differ.Add(word, 0);
                    }
                    differ[word]--;
                    if (differ[word] == 0)
                    {
                        differ.Remove(word);
                    }
                }
                // 如果这个滑动窗口中所有的都没有差异，那么这个滑动窗口的开始下标就是答案之一
                if (differ.Count == 0)
                {
                    result.Add(start);
                }
            }
        }
        return result;
    }
```

 挖个坑，明天先写Rust版本的题解，看看还掌握多少，另外一定要坚持写Rust，已经重新学几次了。

## 31.下一个排列

自己最开始想的是如果后面的序列等于不等于倒序排列的最大值的话就继续往后面排，但是被空间复杂度给限制了，此题只允许用少量常数，关键我还想了很长时间，只能看答案了。

题解中的意思是我从后往前找，找到第一个比前面小的值`left`，然后再从后面往前找，找到第一个比`left`大的值`right`，之后将这两个值对调，那么现在从`left+1`往后的序列就是从大到小排列的，只需要再将后面这些倒序就可以了

**注意：这里的`left`和`right`是我最初的理解，我以为第一个数的坐标肯定在左边，其实并不是，这两个可以是数组中的任意位置**

```rust
    pub fn next_permutation(nums: &mut Vec<i32>) {
        let len = nums.len() as i32;
        let mut left = len - 2;
        let mut right = len - 1;
        // 找到left
        while left >= 0 && nums[left as usize] >= nums[left as usize + 1] {
            left -= 1;
        }
        // 如果找到的left已经太靠前了，已经越界了，说明当前的数组就是所有排列里面最后的一个了
        if left >= 0 {
            // 找到right，这里的right就是从后往前找第一个大于left的值
            // 需要注意这里的right并不一定需要在left的右边
            while right >= 0 && nums[left as usize] >= nums[right as usize] {
                right -= 1;
            }
            // 经过对调的left之后的数组一定是从大到小排列的
            // LeetCode的网站上面不支持这种方式，实际是vscode是可以的
            (nums[left as usize],nums[right as usize]) = (nums[right as usize],nums[left as usize]);
        }
        // 注意这里重新排列的起始坐标是left+1，因为正常情况下这里的left已经是原本的right的值对调了
        // 也就是说最开始的值已经变成原本的下一位，因为left之后的已经是从大到小排列的了，所以倒序即可
        reverted_nums(nums, left as usize + 1)
    }
    
    pub fn reverted_nums(nums: &mut Vec<i32>, mut left: usize) {
        let mut right = nums.len() - 1;
        while left < right {
            (nums[left as usize],nums[right as usize]) = (nums[right as usize],nums[left as usize]);
            left += 1;
            right -= 1;
        }
    }
```

**疑问：我在Rust中通过与或交换两个数的值，结果不知道是否因为在数组中，导致出现了原本不存在的值，所以有点疑惑，下次需要注意下**

## 32.最长有效括号

第一时间想到了动态规划，但是自己刚开始想到是用`dp[left][right]`存放`bool`类型来表示当前的的区间是否满足要求，之后再想办法得到下一个状态，实际是错误的。

官方题解的做法是`dp[index]`来表示截止到当前坐标的满足条件的最大值，之后再判断下一个的状态。

```rust
    pub fn longest_valid_parentheses(s: String) -> i32 {
        let mut res = 0;
        let mut dp:Vec<usize> = vec![0;s.len()];
        let s: Vec<char> = s.chars().collect();
        for i in 1..s.len() {
            // 如果下一个是'('就跳过，肯定不满足
            if s[i] == ')' {
                // 如果前一个是'('，说明这两个直接满足了，dp[i]=dp[i-2]+2
                if s[i - 1] == '(' {
                    // 需要注意下i<2时数组越界的情况
                    if i >= 2 {
                        dp[i] = dp[i - 2] + 2;
                    } else {
                        dp[i] = 2;
                    }
			  // 如果当前dp[i-1]开始坐标的前面一个是`(`，那么就和现在的这个`)`配对上了
                } else if i - dp[i - 1] > 0 && s[i - dp[i - 1] - 1] == '(' {
                    // 考虑下dp[i-1]开始坐标的前面也满足条件，原本因为开始坐标前面的一个`(`导致连续断了，
                    // 现在这个`(`又dp[i]可以用的了，那么就需要再加上`dp[i-dp[i-1]-2]`了
                    if i - dp[i - 1] >= 2 {
                        dp[i] = dp[i - 1] + dp[i - dp[i - 1] - 2] + 2;
                    } else {
                        dp[i] = dp[i - 1] + 2;
                    }
                }
                if dp[i] > res {
                    res = dp[i];
                }
            }
        }
        res as i32
    }
```

## 33.搜索旋转排序数组

这题的重点就是每次将数组分开之后都会有一个数组是排序的，一个和原本一样是没有排序好的，然后再看`target`是否在排序好的这个区间里面，如果不在话就在另外一个里面

```rust
    pub fn search(nums: Vec<i32>, target: i32) -> i32 {
        let len = nums.len();
        if len == 1 {
            if nums[0] == target {
                return 0;
            } else {
                return -1;
            }
        }
        let mut left = 0;
        let mut right = len - 1;
        while left <= right {
            let mid = (left + right) / 2;
            if nums[mid] == target {
                return mid as i32;
            }
            // 判断mid之前的数组是否是排序好的，如果不是的话就在mid之后
            if nums[0] <= nums[mid] {
                // 判断target是否满足mid之前排序好的数组，如果不满足说明在mid后面
                if nums[0] <= target && target <= nums[mid] {
                    right = mid - 1;
                } else {
                    left = mid + 1;
                }
            } else {
                // 判断target是否满足mid之后排序好的数组，如果不满足说明在mid前面
                if nums[mid] <= target && target <= nums[len - 1] {
                    left = mid + 1;
                } else {
                    right = mid - 1;
                }
            }
        }
        -1
    }
```

## 34.在排序数组中查找元素的第一个和最后一个位置

因为题目已经要求时间复杂度是`O(log n)`所以我直接一个二分法的做，果然哈，很快，一个小时不到三种写法写完，美滋滋

你问我官方的方法是不是更简单，这我就不知道了，因为我直接一个不看

![](https://s2.loli.net/2022/08/03/mDzs1a36jqZBJ2H.png)

```rust
    pub fn search_range(nums: Vec<i32>, target: i32) -> Vec<i32> {
        let mut left: i32 = 0;
        let mut right: i32 = nums.len() as i32 - 1;
        while left <= right {
            let mid = (left + right) / 2;
            if nums[mid as usize] == target {
                let mut begin = mid;
                let mut end = mid;
                while begin > 0 && nums[begin as usize - 1] == target {
                    begin -= 1;
                }
                while end < nums.len() as i32 - 1 && nums[end as usize + 1] == target {
                    end += 1;
                }
                return vec![begin, end];
            } else if nums[mid as usize] < target {
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        return vec![-1, -1];
    }
```

## 35.搜索插入位置

也是直接二分，无需多言，附上我的战绩及优美代码，要是所有题都能做这么快就好了。

![](https://s2.loli.net/2022/08/05/qTca2yVoCluUDQZ.png)

```rust
    pub fn search_insert(nums: Vec<i32>, target: i32) -> i32 {
        let mut left = 0;
        let mut right = nums.len() - 1;
        while left <= right {
            if target < nums[left] {
                return left as i32;
            } else if target > nums[right] {
                return right as i32 + 1;
            } else {
                let mid = (left + right) / 2;
                if target < nums[mid] {
                    right = mid - 1;
                } else if target > nums[mid] {
                    left = mid + 1;
                } else {
                    return mid as i32;
                }
            }
        }
        0
    }
```

## 36.有效的数独

自己的解法和官方的差不多，基本都是先横着找再竖着找，然后小方块小方块的找，找到之后判断这个是否符合数独的要求，over。

看了下一题的题目，我估计我要看答案了。

## 37.解数独

果然这题是直接看的答案，而且还没有去理解，不知道为啥就是不想做这题，先这样吧。

## 38.外观数列

这题没有什么需要特别说的，思想基本都差不多，其实都是递归，官方的题解就是没有再写一个方法

另外通过这题知道了有一种方式叫做打表，就是先把所有的答案都写出来。

## 39.组合总和

自己的想法是贪心+递归从后往前找，但是这种情况下有导致有些数值被跳过去，下面说下针对官方题解的理解。

这题官方的题解感觉不如网友“liweiwei1419”的清晰，这里说下关于这个题解的理解：

考虑情况`candidates = [2, 3, 6, 7]`，`target=7`：

* 当第一个数字是`2`，如果找到后续的总和为`7-2=5`的所有组合，再在前面加上`2`，就是第一个是`2`的所有满足条件的组合
* 当第一个数字是`3`，同理找到组合为`7-3=4`的所有组合，再在前面加上`3`，就是第一个数字是`3`的所有满足条件的组合

基于以上的想法，可以画出如下树形图：

![](https://s2.loli.net/2022/08/09/N3r5eFzfvkh9ZV6.png)

说明：

* 以`target=7`为根节点，创建一个分支时做减法；
* 每一个箭头表示：从父节点的数值减去边上的数值，得到子节点的数值。边的值就是题目中给出的`candidate`数组的每个元素的值；
* 减到`0`或者负数的时候停止，即：节点`0`和负数节点成为子节点；
* 所有从根节点到节点`0`的路径（只能从上往下，没有回路）就是题目中要找的一个结果。

这棵树有`4`个子节点的值为`0`，对应的路径是`[2,2,3],[2,3,2],[3,2,2],[7]`，可以看到有重复的了。

思考为什么会产生重复，其实就是因为假如我在以`3`为第一个结果的时候，还添加了`2`，实际上这个已经添加过了。那么为了解决这个问题，包括在之后的不计算顺序的问题的时候，我们可以在搜索的时候按照某种顺序搜索。具体的做法就是：每一次搜索的时候设置下一轮搜索的起点`begin`，如下图：

![](https://s2.loli.net/2022/08/09/L2v6Tl7hPm4eqCk.png)

即：从每一层的第`2`个节点开始，都不能再搜索产生同一层节点已经使用过的`candidate`里的元素，这里放下根据这种思路写的`C#`代码

```c#
public class Solution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        int len = candidates.Length;
        IList<IList<int>> res = new List<IList<int>>();
        if (len == 0)
        {
            return res;
        }
        Stack<int> path = new Stack<int>();
        dfs(candidates, 0, len, target, path, res);
        return res;
    }

    public void dfs(int[] candidates, int begin, int len, int target, Stack<int> path, IList<IList<int>> res)
    {
        if (target < 0)
        {
            return;
        }
        if (target == 0)
        {
            res.Add(new List<int>(path));
            return;
        }
        for (int i = begin; i < len; i++)
        {
            path.Push(candidates[i]);
            dfs(candidates, i, len, target - candidates[i], path, res);
            path.Pop();
        }
    }
}
```

## 40.组合总和II

这题和上面一题有一点相似，但是要求不能有重复的组合，通过以下两步就可以做到

```c#
public class Solution
{
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        int len = candidates.Length;
        IList<IList<int>> res = new List<IList<int>>();
        if (len == 0)
        {
            return res;
        }
        // 首先是这里的需要对这个数组进行排序，为了下一步做准备
        Array.Sort(candidates);
        Stack<int> path = new Stack<int>();
        Dsf2(candidates, 0, len, target, path, res);
        return res;
    }

    public void Dsf2(int[] candidates, int begin, int len, int target, Stack<int> path, IList<IList<int>> res)
    {
        if (target == 0)
        {
            List<int> newPath = new(path);
            newPath.Sort();
            res.Add(newPath);
            return;
        }
        for (int i = begin; i < len; i++)
        {
            if (target - candidates[i] < 0)
            {
                break;
            }
            // 这一步的剪枝，就是如果这个数并不是开始的第一个数，并且这个数和前面的那一个相同就说明这个组合是重复的
            if (i > begin && candidates[i] == candidates[i - 1])
            {
                continue;
            }
            path.Push(candidates[i]);
            Dsf2(candidates, i + 1, len, target - candidates[i], path, res);
            path.Pop();
        }
    }
}
```

## 41.缺失的第一个正数

只能说困难题不愧是困难题啊，是真的不会做啊，说下官方题解的理解吧。

本题的难点在于对于空间复杂度的要求，如果没有要求的话完全可以用一个哈希表把这个数字是否出现存下来，然后遍历一遍就行了，现在的方法就是在原有数组上实现一个类型哈希表的结果，来记录当前的数是否出现过。

1. 首先明确一点，对于一个长度为`len`的数组，最终的结果一定是在`1~len+1`之间，这一点比较容易想明白
2. 对于那些`nums[i]<=0`的数，可以直接把这个数设置为一个`len+1`，这里设置成什么是无所谓的，只要大于`len`即可，反正也不会用到
3. 这一步是关键：**如果`nums[i]<=len`，那么就表示这个数字出现在了`1~len+1`这个区间内了，那么我就将第`nums[i]-1`设置打上标记，题解中的打标记采用的是取负数的方式，第一要注意，这里的`nums[i]-1`是新的坐标，这个坐标一定在`nums`的范围内的，这样当判断`nums[i]<=0`时，就可以知道`i+1`这个数在`nums`中出现过**
4. 还有一些细节，就是在第3步中每次取`nums[i]` 的时候，这个数可以因为前面的数导致变成负数了，所以在每次取之前需要都取一下绝对值
5. 最终再来一次遍历，我们找到第一个`nums[i]>0`的即可，这样就表示`i+1`这个数没有出现过并且`1~i`都出现了，如果都出现了我们就返回`len+1`即可。

```c++
class Solution
{
public:
    int firstMissingPositive(vector<int> &nums)
    {
        int len = nums.size();
        // 
        for (int i = 0; i < len; i++)
        {
            if (nums[i] <= 0)
            {
                nums[i] = len + 1;
            }
        }
        for (int i = 0; i < len; i++)
        {
            int num = abs(nums[i]);
            if (num <= len)
            {
                // 这里需要注意下，新的坐标是num-1
                nums[num - 1] = -abs(nums[num - 1]);
            }
        }
        for (int i = 0; i < len; i++)
        {
            if (nums[i] > 0)
            {
                return i + 1;
            }
        }
        return len + 1;
    }
};
```

![](https://s2.loli.net/2022/08/11/IfbGZBKvedgS41u.jpg)

## 42.接雨水

这题其实自己是做出来的，但是超时了，这里把自己的做法和官方的做法都放一下

```go
// 自己的做法的中心思想就是一行一行算，然后计算这一行符合条件的值
func trap(height []int) int {
	res := 0
	begin := 0
	end := len(height) - 1
	maxDiffer := 0
	for i := 0; i < len(height); i++ {
		if height[i] > maxDiffer {
			maxDiffer = height[i]
		}
	}

	for differ := 0; differ < maxDiffer-1; differ++ {
		begin, end = getNewBeginAndEnd(height, differ, begin, end)
		lineRes := 0
		for index := begin + 1; index < end; index++ {
			if height[index]-differ <= 0 {
				lineRes++
			}
		}
		res += lineRes
	}
	return res
}

func getNewBeginAndEnd(height []int, differ, oldBegin, oldEnd int) (int, int) {
	var newBegin, newEnd int
	for newBegin = oldBegin; newBegin < oldEnd; newBegin++ {
		if height[newBegin]-differ > 0 {
			break
		}
	}
	for newEnd = oldEnd; newEnd > oldBegin; newEnd-- {
		if height[newEnd]-differ > 0 {
			break
		}
	}
	return newBegin, newEnd
}
```

> 官方接法->动态规划(DP)

```c#
    public int Trap(int[] height)
    {
        int res = 0;
        int len = height.Length;
        if (len == 0) return 0;
        // leftMax表示当前坐标的左边的最大值
        int[] leftMax = new int[len];
        leftMax[0] = height[0];
        for (int i = 1; i < len; i++)
        {
            leftMax[i] = Math.Max(leftMax[i-1],height[i]);
        }
        int[] rightMax = new int[len];
        // rightMax表示当前坐标右边的最大值
        rightMax[len - 1] = height[len - 1];
        for (int i = len - 2; i >= 0; i--)
        {
            rightMax[i] = Math.Max(rightMax[i+1],height[i]);
        }
        for (int i = 0; i < len; i++)
        {
            // leftMax[i]和right[i]的较小值减去当前坐标值就是当前坐标能盛放的雨水
            res += Math.Min(leftMax[i],rightMax[i]) - height[i];
        }
        return res;
    }
```

## 43.字符串相乘

自己也写了一版，但是会有`i32`越界的问题，这里说下官方的两种解法

**第一种，模拟乘法的过程**

这种方法其实就是用第一个字符串依次倒叙乘以第二个的数，然后再实现一个字符串的加法

```go
func multiply(num1 string, num2 string) string {
	if num1 == "0" || num2 == "0" {
		return "0"
	}
	res := "0"
	len1, len2 := len(num1), len(num2)
	for i := len2 - 1; i >= 0; i-- {
		curr := ""
		add := 0
		for j := len2 - 1; j > i; j-- {
			curr += "0"
		}
		y := int(num2[i] - '0')
		for j := len1 - 1; j >= 0; j-- {
			x := int(num1[j] - '0')
			product := x*y + add
			curr = strconv.Itoa(product%10) + curr
			add = product / 10
		}
		for ; add != 0; add /= 10 {
			curr = strconv.Itoa(add%10) + curr
		}
		res = addStrings(res, curr)
	}
	return res
}

func addStrings(num1 string, num2 string) string {
	index1, index2 := len(num1)-1, len(num2)-1
	add := 0
	res := ""
	for ; index1 >= 0 || index2 >= 0 || add != 0; index1, index2 = index1-1, index2-1 {
		x, y := 0, 0
		if index1 >= 0 {
			x = int(num1[index1] - '0')
		}
		if index2 >= 0 {
			y = int(num2[index2] - '0')
		}
		tempRes := x + y + add
		res = strconv.Itoa(tempRes%10) + res
		add = tempRes / 10
	}
	return res
}
```

**第二种，其实也是乘法的过程**

这种方法是：

1. 先用一个`len1+len2`的数组来盛放所有的内容，为什么是`len1+len2`是因为一个`len1` 的数组乘以一个`len2`的数组的新答案肯定小于等于`len1+len2`，
2. 将`num1[i]*num2[j]`的数字相乘放在新数组的`i+j+1`这个位置，至于为什么是这个位置需要好好的观察一下
3. 之后将新数组的按照十进制的方式整理下即可，注意这里最前面可能是`0`,记得舍弃掉

```java
class Solution {
    public String multiply(String num1, String num2) {
        if (num1.equals("0") || num2.equals("0")) {
            return "0";
        }
        StringBuilder res = new StringBuilder();
        int len1 = num1.length();
        int len2 = num2.length();
        int[] resArr = new int[len1 + len2];

        for (int i = len1 - 1; i >= 0; i--) {
            int x = num1.charAt(i) - '0';
            for (int j = len2 - 1; j >= 0; j--) {
                int y = num2.charAt(j) - '0';
                resArr[i + j + 1] += x * y;
            }
        }

        for (int i = len1 + len2 - 1; i > 0; i--) {
            resArr[i - 1] += resArr[i] / 10;
            resArr[i] %= 10;
        }

        int begin = resArr[0] == 0 ? 1 : 0;
        for (int i = begin; i < len1 + len2; i++) {
            res.append(resArr[i]);
        }
        return res.toString();
    }
}
```

