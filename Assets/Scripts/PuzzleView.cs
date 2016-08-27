﻿using UnityEngine;
using System.Collections.Generic;

public class PuzzleView : MonoBehaviour
{
    public GameObject m_panel;
    public PuzzleLetterView m_prefab;
    
    void Start()
	{
        Game game = Game.Instance;
        game.InitPuzzle();

        Puzzle puzzle = game.currentPuzzle;
        float currentX = -100;
        float currentY = 0;
        int count = 0;
        foreach (var glyph in puzzle.glyphs)
        {
            GameObject newObj = Instantiate(m_prefab.gameObject);

            newObj.name = "glyph_" + (count++).ToString();
            PuzzleLetterView plv = newObj.GetComponent<PuzzleLetterView>();
            LetterBoxView lbv = newObj.GetComponent<LetterBoxView>();

            lbv.m_letter = glyph.Letter.ToString();
            lbv.m_text.text = glyph.Letter.ToString();

            newObj.transform.SetParent(m_panel.transform);
            RectTransform newTransform = newObj.GetComponent<RectTransform>();
            newTransform.localPosition = new Vector2(currentX, currentY);

            currentX += newObj.GetComponent<RectTransform>().rect.width;
        }

        m_prefab.gameObject.SetActive(false);
	}

	void Update()
	{
	}

}