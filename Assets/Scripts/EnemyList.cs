using System.Collections.Generic;
using UnityEngine;

public class EnemyList : MonoBehaviour
{
   public List<Status> enemys = new List<Status>
            {
                new Status {eHp = 50,eAtt = 45 ,eDef=5, eRes = 5, eAgi = 10},�@//�P�R�m

                new Status {eHp = 55,eAtt = 50 ,eDef=15, eRes = 0, eAgi = 10},�@//�Q�R��

                new Status {eHp = 50,eAtt = 50 ,eDef=15, eRes = 5, eAgi = 15},�@//�R�R��(��)

                new Status {eHp = 55,eAtt = 50 ,eDef=15, eRes = 0, eAgi = 10},�@//�S�R��

                new Status {eHp = 50,eAtt = 50 ,eDef=15, eRes = 10, eAgi = 15},�@//�T�`����

                new Status {eHp = 50,eAtt = 50 ,eDef=15, eRes = 5, eAgi = 15},�@//�U���

                new Status {eHp = 60,eAtt = 55 ,eDef=15, eRes = 15, eAgi = 20},�@//�V������

                new Status {eHp = 60,eAtt = 55 ,eDef=15, eRes = 5, eAgi = 10},�@//�W���K��

                new Status {eHp = 55,eAtt = 50 ,eDef=15, eRes = 10, eAgi = 15},�@//�X�b��

                new Status {eHp = 60,eAtt = 55 ,eDef=15, eRes = 5, eAgi = 10},�@//�P�O���K����

                new Status {eHp = 40,eAtt = 50 ,eDef=15, eRes = 0, eAgi = 10}�@ //�P�P�Z�l
            };
}
