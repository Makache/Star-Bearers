using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tribe : MonoBehaviour
{
    [SerializeField] private Leader _leader;
    [SerializeField] private List<Member> _members = new List<Member>();

    private void Start()
    {
        DistributeMembers();
    }

    private void DistributeMembers()
    {
        //float minDistanceToNeighbour = 10000f;
        //float distanceToNeighbour;
        int neighbourIndex = 0;

        for (int i = 0; i < _members.Count; i++)
        {
            for (int j = 0; j < _members.Count; j++)
            {
                if (i == 0) _members[i].SetNearestNeighbour(_leader.gameObject);

                if (i == j) continue;

                //distanceToNeighbour = Vector3.Distance(_members[i].gameObject.transform.position, _members[j].gameObject.transform.position);

                /*if (minDistanceToNeighbour > distanceToNeighbour)
                {
                    minDistanceToNeighbour = distanceToNeighbour;
                    neighbourIndex = j;
                }*/
                neighbourIndex = Random.Range(1, 20);
            }
            if (_members[neighbourIndex].MaxFollowersCount == 0)
            {
                _members[i].SetNearestNeighbour(_leader.gameObject);
            }
            else if (i != 0 && _members[neighbourIndex].MaxFollowersCount >= _members[neighbourIndex].FollowersCount)
            {
                _members[i].SetNearestNeighbour(_members[neighbourIndex].gameObject);
                _members[neighbourIndex].FollowersCount++;
            }
            else if (_members[neighbourIndex].MaxFollowersCount < _members[neighbourIndex].FollowersCount)
            {
                for (int l = 1; l < _members.Count; l++)
                {
                    if (_members[l].MaxFollowersCount >= _members[l].FollowersCount)
                    {
                        _members[i].SetNearestNeighbour(_members[l].gameObject);
                        break;
                    }
                }
                if (_members[i].Neighbour == null)
                {
                    _members[i].SetNearestNeighbour(_leader.gameObject);
                }

            }
        }
    }
}