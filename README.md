# Nike-Account-Generator-written-in-Csharp

Bug: 
1. User-Agent from BOGUS sometimes is unusable causing the form of the website to change. Put in your own User-Agent to be sure.

Things to add:
1. SMSCODE API support
2. Rewrite the loop to have better error-handle
3. Proxy Support

# Update: 
This project is archived.

This is very basic selenium usage with no resquest involved.

Tips: 
The key to make this kind of bot work is to have a good User-Agent base (HAS to be good and reasonable user-agent, a randomized UA won't pass)that can "pass" nike's antibot detection. (Also a randomized delay between each action to make the process as humanized as possible.) Different ips are suggested as they tend to flag accounts created by same IP (Not sure, I think as long as the IP isn't flagged by Nike at first the accounts created should work). I've tried to use requests to bulk create accounts. It's really efficient but the accounts won't work at all and are flagged by Nike. If you create accounts successfully using script, the accounts will work. 

This project is for academic and learning purposes. You can refer back to find the Xpath/elements of nike's web source but DON'T make a profit from it because I didn't implement proxy support and SMS api. 

This project is archived.

