using TMPro;
using UnityEngine;

public class PuzzleUIManager : MonoBehaviour
{
    public TextMeshPro title;
    public TextMeshPro description;
    public static PuzzleUIManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        title.SetText("");
        description.SetText("");
    }

    public void TowerOfBabel()
    {
        title.SetText("Tower of Babel");
        description.SetText("Pieter Bruegel the Elder's \"The Tower of Babel\" (1563) is a renowned painting depicting the biblical narrative of human ambition and divine intervention." +
            " The artwork showcases a bustling construction site with intricate details, vibrant colors, and a panoramic landscape, emphasizing Bruegel's keen observation of everyday life" +
            ". The tower's vertical ascent symbolizes human aspirations while exploring the consequences of challenging divine authority.");
    }

    public void KosovkaDevojka()
    {
        title.SetText("Kosovka devojka");
        description.SetText("Uros Predic's 'Kosovka Devojka,' painted in 1919, vividly depicts the aftermath of the Battle of Kosovo in 1389. " +
            "The scene, set in a dawn-lit summer landscape with blooming poppies, portrays a wounded Serbian hero, Orlovic Pavle, receiving aid from an unnamed maiden. " +
            "Laden with symbolism, the painting captures themes of sacrifice, honor, and the enduring spirit of the homeland.");
    }

    public void Forest()
    {
        title.SetText("Virgin Forest \nwith Sunset");
        description.SetText("Henri Rousseau's \"Virgin Forest with Sunset,\" a post-impressionist masterpiece from 1910, " +
            "showcases the lushness of a dense forest bathed in warm sunset hues. Despite being ridiculed by contemporary critics, Rousseau, known as" +
            " \"Le Douanier\" due to his customs officer background, embraced the Naïve style, demonstrating self-taught genius. The painting's unique color, " +
            "form, and composition have left a lasting impact on avant-garde artists, cementing Rousseau's legacy as a pioneering figure in the art world.");
    }

    public void Wave()
    {
        title.SetText("The Great Wave \noff Kanagawa");
        description.SetText("\"The Great Wave off Kanagawa\" is a iconic woodblock print by Japanese ukiyo-e artist Katsushika Hokusai, created around 1831." +
            " This masterpiece, part of the series \"Thirty-Six Views of Mount Fuji,\" features a towering wave about to crash over three small boats with " +
            "Mount Fuji in the background. The dynamic composition, dramatic wave, and vivid contrasts make it a symbol of Japanese art and one of the most " +
            "recognized prints globally.");
    }

    public void Moonlight()
    {
        title.SetText("The Island of Patmos");
        description.SetText("\"The Island of Patmos\" by Ivan Aivazovsky is a maritime masterpiece painted in the 19th century. This artwork captures the serene beauty " +
            "of the Greek island of Patmos under a moonlit sky. Aivazovsky, a renowned Russian Romantic painter, skillfully depicts the play of moonlight on the tranquil " +
            "waters, showcasing his mastery of light and atmosphere. The painting reflects the artist's deep connection to marine themes and his ability to evoke a sense " +
            "of ethereal tranquility in his seascapes.");
    }

    public void WaterLilly()
    {
        title.SetText("Water Lily Pond");
        description.SetText("Claude Monet's \"Water Lily Pond\" is an Impressionist masterpiece painted around 1899. Part of his extensive series featuring " +
            "his beloved Giverny garden, this artwork captures the serene beauty of water lilies floating on a pond. Monet's use of vibrant colors, loose brushstrokes, " +
            "and the play of light reflects the essence of Impressionism, conveying a sense of tranquility and the ever-changing nature of the scene. The painting is a " +
            "testament to Monet's fascination with capturing the nuances of light and atmosphere in the natural world.");
    }
}
