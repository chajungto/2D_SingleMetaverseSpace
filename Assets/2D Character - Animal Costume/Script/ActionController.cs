using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Asset
{

    public class ActionController : MonoBehaviour
    {
        public List<GameObject> characterPrefabs;
        public List<GameObject> effectPrefabs;
        public Transform characterParent;
        public Transform spawnPos;
        public Transform targetPos;
        public GameObject currentCharacterStyle;
        public GameObject currentCharacter;

        public IEnumerator ActionScript()
        {
            //Front actions
            //1.Rabbit, Greetings
            StartCoroutine(Action(0, "Front", "greetingFront", 5, "pop"));
            yield return new WaitForSeconds(1f);
            //2.Devil, Happy
            StartCoroutine(Action(1, "Front", "happyFront", 0, "happy"));
            yield return new WaitForSeconds(1.5f);
            //3.Shark, Angry
            StartCoroutine(Action(2, "Front", "angryFront", 1, "angry"));
            yield return new WaitForSeconds(1.4f);
            //4.Deer, Suprise
            StartCoroutine(Action(3, "Front", "supriseFront", 2, "suprise"));
            yield return new WaitForSeconds(0.833f);
            //5.Frog, Sad
            StartCoroutine(Action(4, "Front", "sadFront", 3, "sad"));
            yield return new WaitForSeconds(1.25f);
            //6.Dog, Think/idle
            StartCoroutine(Action(5, "Front", "idleFront", 4, "thinking"));
            yield return new WaitForSeconds(2f);
            //7.Panda, Talk
            StartCoroutine(Action(6, "Front", "talkFront", -1, ""));
            yield return new WaitForSeconds(2.25f);

            //8.Cat, Walk
            StartCoroutine(Action(7, "Side", "walk", 6, "sing"));
            Debug.Log(Vector3.Distance(currentCharacter.transform.position, targetPos.position));
            while (Vector3.Distance(currentCharacter.transform.position, targetPos.position) > 0.1f)
            {
                currentCharacter.transform.position = Vector3.MoveTowards(currentCharacter.transform.position, targetPos.position, 2f * Time.deltaTime);
                yield return null;
            }
            StartCoroutine(ActionScript());
        }

        public IEnumerator Action(int characterID, string characterStyle /* Front, Back, Side */, string characterAnimation, int effectID, string effectAnimation)
        {
            DestroyAll();
            //style
            currentCharacter = Instantiate(characterPrefabs[characterID], characterParent);
            currentCharacter.transform.position = spawnPos.position;

            //Activate Characters in Child
            currentCharacterStyle = null;
            Transform effectParent = null;

            foreach (Transform characterTransform in currentCharacter.GetComponentsInChildren<Transform>())
            {
                if (characterTransform == currentCharacter.transform) continue;
                characterTransform.gameObject.SetActive(characterTransform.name == characterStyle || characterTransform.name == "Effect");
                if (characterTransform.name == characterStyle) currentCharacterStyle = characterTransform.gameObject;
                if (characterTransform.name == "Effect") effectParent = characterTransform;
            }

            //Play Animation
            currentCharacterStyle.GetComponent<Animator>().Play(characterAnimation);

            //Spawn Effect
            if (effectID < 0) yield break;
            var effect = Instantiate(effectPrefabs[effectID], effectParent);
            effect.GetComponent<Animator>().Play(effectAnimation);
            yield return new WaitForSeconds(effect.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            Destroy(effect);
        }

        public void DestroyAll()
        {
            foreach (Transform characterTransform in characterParent)
            {
                if (characterTransform == characterParent.transform) continue;
                Destroy(characterTransform.gameObject);
            }
        }

        private void Start()
        {
            StartCoroutine(ActionScript());
        }
    }

}
