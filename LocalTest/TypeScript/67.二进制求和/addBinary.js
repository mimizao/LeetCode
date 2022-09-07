"use strict";
function addBinary(a, b) {
    if (a.length >= b.length) {
        return myAddBinary(a, b);
    }
    else {
        return myAddBinary(b, a);
    }
}
function myAddBinary(a, b) {
    let aLen = a.length;
    let bLen = b.length;
    let aArr = a.split("");
    let bArr = Array(aLen);
    let res = Array(aLen);
    for (let i = 0; i < aLen; i++) {
        if (i < bLen) {
            bArr[aLen - i - 1] = b[bLen - i - 1];
        }
        else {
            bArr[aLen - i - 1] = "0";
        }
    }
    let flag = 0;
    for (let i = aLen - 1; i >= 0; i--) {
        let temp = Number(aArr[i]) + Number(bArr[i]) + flag;
        switch (temp) {
            case 3:
                res[i] = "1";
                flag = 1;
                break;
            case 2:
                res[i] = "0";
                flag = 1;
                break;
            case 1:
                res[i] = "1";
                flag = 0;
                break;
            default:
                res[i] = "0";
                flag = 0;
        }
    }
    if (flag == 1) {
        return "1" + res.join("");
    }
    return res.join("");
}
let a = "10100000100100110110010000010101111011011001101110111111111101000000101111001110001111100001101";
let b = "110101001011101110001111100110001010100001101011101010000011011011001011101111001100000011011110011";
console.log(addBinary(a, b));
//# sourceMappingURL=addBinary.js.map