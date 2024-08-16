INCLUDE globals.ink

{getTaskState("GoExploring"):
- "REQUIREMENTS_NOT_MET": -> start
- "CAN_START": -> start
- "IN_PROGRESS": -> end_negative
- "FINISHED": -> ended

}

=== start ===
Siema! Masz może dla mnie jakąś misję? #speaker:Maciek #portrait:maciek_neutral #layout:left
Witaj. Akurat tak się składa, że mam. #speaker:Zbych #portrait:zbych_neutral #layout:right
Chcę, abyś odwiedził Akademik, Sklep i Parking
Na parkingu musisz podejść na lewo od dwóch zielonych samochodów.
Czekaj...
A może jednak na prawo?
Kurwa...
Zresztą, wisi mi to... Sprawdzisz to sam!
Czy przyjmujesz moją misję?
 * [Nie] Nie, sory... #speaker:Maciek #portrait:maciek_neutral #layout:left
    To <color=\#fc0303>s p i e r d a l a j!</color>#speaker:Zbych #portrait:zbych_neutral #layout:right
    -> END
 * [Tak #getsTask: GoExploring] Tak, lecimy z tematem!#speaker:Maciek #portrait:maciek_neutral #layout:left 
    Git, tylko nie pojeb kolejności!#speaker:Zbych #portrait:zbych_neutral #layout:right
    -> END
    
=== end_negative ==
I co, udało ci się? #speaker:Zbych #portrait:zbych_neutral #layout:right
Emm, jeszcze nie... #speaker:Maciek #portrait:maciek_neutral #layout:left
No to co mi dupę zawracasz! #speaker:Zbych #portrait:zbych_neutral #layout:right
Raz dwa, do zwiedzania!
-> END

=== ended ===
Siema! Masz może dla mnie jakąś misję? #speaker:Maciek #portrait:maciek_neutral #layout:left
Witaj. Wypełniłeś już moją misję. #speaker:Zbych #portrait:zbych_neutral #layout:right
O, faktycznie... Jak będzie coś nowego to daj mi znać! #speaker:Maciek #portrait:maciek_neutral #layout:left
-> END