#include <iostream>
#include <cstdio>
using namespace std;

/* Returns maximum among the four integers
 * Author: Siken Man Singh Dongol 
 */
 
int max_of_four(int a, int b, int c, int d) {
    int ab, cd;
    
    if(a>=b) ab=a; else ab = b;
    if(c>=d) cd=c; else cd = d;
    
    if(ab>=cd) return ab;
     else return cd;
}

int main() {
    int a, b, c, d;
    scanf("%d %d %d %d", &a, &b, &c, &d);
    int ans = max_of_four(a, b, c, d);
    printf("%d", ans);
    
    return 0;
}
