# 가장 큰 수 
## javascript

<pre>
<code>
function solution(numbers) {
    var arr = numbers.map(n => n.toString());
    var answer = arr.sort((a,b) => (b+a) - (a+b)).join("");
    answer[0] === "0" ? answer = "0" : answer;
    return answer;
}
</code>
</pre>

# k번째수
## javascript

<pre>
<code>
function solution(array, commands) {
    var temp_arr = [];
    for(var i=0; i<commands.length; i++){
        var start = commands[i][0];
        var end = commands[i][1];
        var point = commands[i][2];

        var a = array.slice(start - 1, end);
        var sort = a.sort((a,b)=> (a-b));
        var result = sort[point-1];
        temp_arr.push(result);
    }
    var answer = temp_arr;
    return answer;
}
</code>
</pre>