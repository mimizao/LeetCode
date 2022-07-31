/*
 * @lc app=leetcode.cn id=30 lang=golang
 *
 * [30] 串联所有单词的子串
 */
package main

// @lc code=start

func findSubstring(s string, words []string) (ans []int) {
	sLen, wordsLen, wordLen := len(s), len(words), len(words[0])
	for i := 0; i < wordLen && i+wordsLen*wordLen <= sLen; i++ {
		differ := map[string]int{}
		for j := 0; j < wordsLen; j++ {
			differ[s[i+j*wordLen:i+(j+1)*wordLen]]++
		}
		for _, word := range words {
			differ[word]--
			if differ[word] == 0 {
				delete(differ, word)
			}
		}
		for start := i; start < sLen-wordsLen*wordLen+1; start += wordLen {
			if start != i {
				word := s[start+(wordsLen-1)*wordLen : start+wordsLen*wordLen]
				differ[word]++
				if differ[word] == 0 {
					delete(differ, word)
				}
				word = s[start-wordLen : start]
				differ[word]--
				if differ[word] == 0 {
					delete(differ, word)
				}
			}
			if len(differ) == 0 {
				ans = append(ans, start)
			}
		}
	}
	return
}

// @lc code=end
