# 스톤게임
## javascript
### 문제 이해를 잘못했는지 틀렸음..
<pre>
<code>
/**
 * @param {number[]} piles
 * @return {boolean}
 */
var stoneGame = function(piles) {
    var lang = piles.length;
    var a_arr = [];
    var b_arr = [];

    let j = lang - 1;
    var count = 1;
    for (var i = 0; i <= lang; i++) {
        //console.log("ccc ", piles);

        if (lang <= 0) {
            b_arr.push(piles[0]);
            break;
        }
        var start = piles[0];
        var end = piles[piles.length - 1];
        var turn = count % 2;
        var select;
        // console.log("turn ", turn);
        // console.log(start);
        // console.log(end);
        if (turn != 0) { // 엘리스 순서일때
            if (start > end) { //앞 값이 클때
                a_arr.push(start);
                select = 0;
            } else if (start < end) { // 맨뒤 값이 클때
                a_arr.push(end);
                select = 1;
            } else if (start == end) { // 앞끝이 같을때 그다음 인덱스로 비교
                if (piles[1] < piles[piles.length - 2]) {
                    a_arr.push(start);
                    select = 0;
                } else {
                    a_arr.push(end);
                    select = 1;
                }
            }
            //console.log("a", a_arr);
        } else if (turn == 0) {
            if (start > end) {
                b_arr.push(start);
                select = 0;
            } else if (start < end) {
                b_arr.push(end);
                select = 1;
            } else if (start == end) {
                if (piles[1] < piles[piles.length - 2]) {
                    b_arr.push(start);
                    select = 0;
                } else {
                    b_arr.push(end);
                    select = 1;
                }
            }
           // console.log("b", b_arr);
        }
    
        if (select == 0) {
            piles.shift();
        } else {
            piles.pop();
        }


        //console.log("rrr ", piles);
        lang = piles.length;
        i = 0;
        count++;
    }



    const a_result = a_arr.reduce((acc, cur) => {
        return acc + cur;
    }, 0);
    const b_result = b_arr.reduce((acc, cur) => {
        return acc + cur;
    }, 0);
    return a_result > b_result;
};
</code>
</pre>

