import { atom } from "jotai";

export const isAuthenticatedAtom = atom(false);
export const userRoleAtom = atom<string>(""); 