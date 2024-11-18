using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventManager : MonoBehaviour
{
    public TextMeshProUGUI titleText; 
    public TextMeshProUGUI quoteText; 
    public TextMeshProUGUI infoText; 

    private List<RandomEvent> events = new List<RandomEvent>();

    private bool isAnimating = false;

    void Start()
    {
        InitializeEvents();
    }

    public void TriggerRandomEvent()
    {
        if (isAnimating) return;

        RandomEvent randomEvent = events[Random.Range(0, events.Count)];

        titleText.text = randomEvent.title;
        
        StartCoroutine(ShowQuoteThenInfo(randomEvent));
    }

    private IEnumerator ShowQuoteThenInfo(RandomEvent randomEvent)
    {
        isAnimating = true;

        quoteText.text = randomEvent.quote;
        infoText.text = randomEvent.description;
        quoteText.gameObject.SetActive(true);
        infoText.gameObject.SetActive(false);

        yield return StartCoroutine(FadeText(quoteText, fadeIn: true, duration: 1f));

        yield return new WaitForSeconds(1f);

        yield return StartCoroutine(FadeText(quoteText, fadeIn: false, duration: 1f));

        quoteText.gameObject.SetActive(false);
        infoText.gameObject.SetActive(true);

        yield return StartCoroutine(FadeText(infoText, fadeIn: true, duration: 1f));

        isAnimating = false;
    }

    private IEnumerator FadeText(TextMeshProUGUI text, bool fadeIn, float duration)
    {
        Color originalColor = text.color;
        float startAlpha = fadeIn ? 0 : 1;
        float endAlpha = fadeIn ? 1 : 0;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            text.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        text.color = new Color(originalColor.r, originalColor.g, originalColor.b, endAlpha);
    }


    private void InitializeEvents()
    {
        // All events 
        events.Add(new RandomEvent
        {
            title = "Soul Reaper",
            quote = "“You've angered the Gods. They have sent a harbinger of death to remove a part of your soul.”",
            description = "The player with the most health loses 5 soul fragments. If none, all players lose 2 soul fragments."
        });

        events.Add(new RandomEvent
        {
            title = "Time Spirit",
            quote = "“Worry not, my friend; the sands of time shift have chosen you, altering the course of fate.”",
            description = "The player with the lowest health and least progress in biomes will be moved on to the next biome and have their health fully restored."
        });

        events.Add(new RandomEvent
        {
            title = "Infirma Nostri Corporis",
            quote = "“A desperate act of self-sacrifice, a desperate gamble. A sacrifice of strength for what? Nothing.”",
            description = "All players will lose 2 battle cards and 1 HP."
        });

        events.Add(new RandomEvent
        {
            title = "Vantanoir",
            quote = "“In the face of nothingness. Even the light will not shed its warmth around you.”",
            description = "The player with the least health will lose half of the total of their battle cards, round down if odds, and deal 2 damage to others. If there’s no least health player, all players will discard 3 cards."
        });

        events.Add(new RandomEvent
        {
            title = "Eternal Night",
            quote = "“Darkness descends, and hope fades.”",
            description = "All players will lose 2 HP and cannot use cards and stations on their next turn."
        });

        events.Add(new RandomEvent
        {
            title = "The Puppeteer",
            quote = "“For the very beginning. All of you, little lumps of light, are destined to be controlled. Watch as I tribute you to a fight that will end one’s life!”",
            description = "All players will now enter the Early Grave event."
        });
        
        events.Add(new RandomEvent
        {
            title = "Abyssal Curse",
            quote = "“You did it. The Abyss started to gaze back at you. Pulling your soul back into the void.”",
            description = "All players will lose 3 soul fragments."
        });

        events.Add(new RandomEvent
        {
            title = "Soul’s Condemnation",
            quote = "“A master of none, a jack of all. Let's trade fortunes, shall we? ”",
            description = "All players will lose 5 HP until after the next 2 turns. Regain 5 HP after this."
        });

        events.Add(new RandomEvent
        {
            title = "Jack of All Trades",
            quote = "“The brightest light will always be the frailest one.”",
            description = "All players must show their non-battle cards and must exchange 1-2 cards in 1 minute. They can cancel if all players are done trading."
        });

        events.Add(new RandomEvent
        {
            title = "Forgotten Monarch",
            quote = "“A monarch who knows who. Gave one last blessing to the exploring souls.”",
            description = "All players will gain 2 battle cards, HP, and 3 Soul Fragments."
        });

        events.Add(new RandomEvent
        {
            title = "Healing Sanctuary",
            quote = "“Finally, a haven of peace. You can rest here, little candle.”",
            description = "The player with the least health gains 4 HP and draws two battle cards, while the others gain 3, 2, and 1 HP in ascending order of health."
        });        

        events.Add(new RandomEvent
        {
            title = "Bloodseeker’s Mark",
            quote = "“Ahh, I sense your blood, boiling from afar. I’ll give you power for a soul.”",
            description = "The player with the fewest wildcards gains 2 random wildcards and receives 2 damage."
        });

        events.Add(new RandomEvent
        {
            title = "Ferryman’s Sorrow",
            quote = "“You listened to the one who rows the sea of the dead, and he gives you a “tantalizing” gift.”",
            description = "All players will draw 1 random biome card and 2 soul fragments."
        });

    }
}

