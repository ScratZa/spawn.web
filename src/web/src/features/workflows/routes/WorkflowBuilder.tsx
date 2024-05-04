import { ContentLayout } from '@/components/Layout';
import { useCallback } from 'react';
import ReactFlow, { Background, Connection, Controls, Edge, MiniMap, addEdge, useEdgesState, useNodesState } from 'reactflow';
 
import 'reactflow/dist/style.css';
 
const initialNodes = [
  { id: '1', position: { x: 0, y: 0 }, data: { label: '1' } },
  { id: '2', position: { x: 0, y: 100 }, data: { label: '2' } },
];
const initialEdges = [{ id: 'e1-2', source: '1', target: '2' }];
 
export const WorkflowBuilder = () => {
    
    const [nodes, setNodes, onNodesChange] = useNodesState(initialNodes);
    const [edges, setEdges, onEdgesChange] = useEdgesState(initialEdges);
   
    const onConnect = useCallback(
      (params: Edge | Connection) => setEdges((eds) => addEdge(params, eds)),
      [setEdges],
    );
   
    return (
    <ContentLayout title="Jobs">
      <div className='bg-slate-600' style={{ width: '80vw', height: '80vh' }}>
        <ReactFlow
          nodes={nodes}
          edges={edges}
          onNodesChange={onNodesChange}
          onEdgesChange={onEdgesChange}
          onConnect={onConnect}
          
        >
        <Controls />
        <MiniMap />
        <Background variant="dots" gap={12} size={1} />
        </ReactFlow>
      </div>
      
      </ContentLayout>
    );
}