import java.util.*;

class Solution {
    public static String[] solution(String[] record) {
        Map<String , String> iDMap =  new HashMap<>();//아이디 닉네임 담기
        StringBuilder st = new StringBuilder(); //정답을 문자열로

        for(String str : record){
            
            String temp[] = str.split(" ");

            if(temp[0].equals("Enter") || temp[0].equals("Change")){
                
                iDMap.put(temp[1],temp[2]); //키가 없으면 생성, 있다면 닉네임 업데이트
            }
        }
        
        
        
        
        for(String str : record){
            String temp[] = str.split(" ");

            if(temp[0].equals("Enter") ){
                st.append(iDMap.get(temp[1])+"님이 들어왔습니다.").append("\n");
            }

            if(temp[0].equals("Leave") ){
                st.append(iDMap.get(temp[1])+"님이 나갔습니다.").append("\n");
            }
        }
        
        String []answer = st.toString().split("\n");

        return answer;
    }
}



=====================================================================




class Solution {
    public long solution(int n) {
        long arr []= new long[2001];
        arr[1]=1;
	    arr[2]=2;
	 
	    for(int i=3; i<2001; i++) {
		    arr[i] = (arr[i-1]+arr[i-2])%1234567;			 
	    } 		 
        
        return arr[n];
    }
}
