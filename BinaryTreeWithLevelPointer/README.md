![image](https://cloud.githubusercontent.com/assets/2216750/23337497/d9a91aa8-fc2a-11e6-9d79-95903bb9b3c9.png)

最终目标： 找到插入的孩子的前驱节点

1. 找到插入的孩子应当指向的下一个节点
2. 找到当前节点所在层
3. 找到有可能会用到的当前层最后一个节点

解法：

1. 从当前节点开始寻找下一个有孩子的节点，孩子为targetNextNode；
2. 继续寻找直到当前节点被LayerHead包含，从而推算出当前节点所在层数，并记录被LayerHead包含的节点的上一个节点currentLayerLastNode
3. 从当前节点所在层的头部开始遍历，遍历至当前节点（不含），记录最后一个有孩子的节点孩子为target
4. 接下来判断当前节点，如果插入的是右孩子且左孩子不为null，则target为当前节点的左孩子。
5. 将新节点next指向target的next，target节点的next指向新节点。如果前驱节点与被添加的孩子节点不在同一层，则更新LayerHead。
