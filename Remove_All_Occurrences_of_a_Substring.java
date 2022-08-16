package Problems;

public class Remove_All_Occurrences_of_a_Substring {
    public static void main(String[] args) {
        String s = "aabababa";
        String part = "aba";


        while (s.contains(part)) {
            s = removeString(s, part);
        }
        System.out.println(s);
    }


    public static String removeString(String s, String part){

        s = s.replaceAll(part,"");// abab

        return s;
    }
}
